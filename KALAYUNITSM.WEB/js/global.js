$.layerOpen = function (options) {
    var defaults = {
        id: "default",
        title: '系统窗口',
        type: 2,
        //skin: 'layui-layer-molv',
        width: "95%",
        height: "95%",
        maxmin: false,
        content: '',
        shade: 0.3,
        btn: ['确认', '关闭'],
        btnclass: ['btn btn-primary', 'btn btn-danger'],
        yes: null
    };
    var options = $.extend(defaults, options);
    top.layer.open({
        id: options.id,
        type: options.type,
        scrollbar: false,
        //skin: options.skin,
        shade: options.shade,
        shadeClose: false,
        maxmin: options.maxmin,
        title: options.title,
        fix: false,
        area: [options.width, options.height],
        content: options.content,
        btn: options.btn,
        btnclass: options.btnclass,
        yes: function (index, layero) {
            if (options.yes && $.isFunction(options.yes)) {
                var iframebody = top.layer.getChildFrame('body', index);
                var iframeWin = layero.find('iframe')[0].contentWindow;
                options.yes(iframebody, iframeWin, index);
            }
        },
        cancel: function (index) {
            return true;
        }
    });

}
$.layerClose = function () {
    var index = top.layer.getFrameIndex(window.name);
    top.layer.close(index);
}
$.layerConfirm = function (options) {
    var defaults = {
        title: '提示',
        //skin: 'layui-layer-molv',
        content: "",
        icon: 3,
        shade: 0.3,
        anim: 2,
        btn: ['确认', '关闭'],
        btnclass: ['btn btn-primary', 'btn btn-danger'],
        callback: null
    };
    var options = $.extend(defaults, options);
    top.layer.confirm(options.content, {
        title: options.title,
        icon: options.icon,
        btn: options.btn,
        btnclass: options.btnclass,
        //skin: options.skin,
        anim: options.anim
    }, function () {
        if (options.callback && $.isFunction(options.callback)) {
            top.layer.closeAll();
            options.callback();
        }
    }, function () {
        top.layer.closeAll();
        return true;
    });
}
$.layerMsg = function (content, type, callback) {
    //debugger;
    if (type != undefined) {
        var icon = "";
        if (type == 'warning' || type == 0) {
            icon = 0;
        }
        if (type == 'success' || type == 1) {
            icon = 1;
        }
        if (type == 'error' || type == 2) {
            icon = 2;
        }
        if (type == 'info' || type == 6) {
            icon = 6;
        }
        top.layer.msg(content, { icon: icon, time: 2000 }, function () {
            if (callback && $.isFunction(callback)) {
                callback();
            }
        });
    } else {
        top.layer.msg(content, function () {
            if (callback && $.isFunction(callback)) {
                callback();
            }
        });
    }
}
$.fn.bindSelect = function (options) {
    var defaults = {
        id: "id",
        text: "text",
        search: true,
        multiple: false,
        title: "请选择",
        url: "",
        param: [],
        selectvalue: "",
        change: null
    };
    var options = $.extend(defaults, options);
    var $element = $(this);
    if (options.url != "") {
        $.ajax({
            url: options.url,
            data: options.param,
            title: options.title,
            type: "post",
            dataType: "json",
            async: false,
            success: function (data) {
                $element.append($("<option></option>").val("").html(options.title));
                $.each(data, function (i) {
                    if (data[i][options.id] == options.selectvalue) {
                        $element.append($("<option selected='selected'></option>").val(data[i][options.id]).html(data[i][options.text]));
                    } else {
                        $element.append($("<option></option>").val(data[i][options.id]).html(data[i][options.text]));
                    }
                });
                $element.select2({
                    placeholder: options.title,
                    //multiple: options.multiple,
                    minimumResultsForSearch: options.search == true ? 0 : -1
                });
                $element.on("change", function (e) {
                    if (options.change != null) {
                        options.change(data[$(this).find("option:selected").index()]);
                    }
                    $("#select2-" + $element.attr('id') + "-container").html($(this).find("option:selected").text().replace(/　　/g, ''));
                });
            }
        });
    } else {
        $element.select2({
            minimumResultsForSearch: -1
        });
    }
}

$.fn.bindRadio = function (options) {
    var defaults = {
        id: "id",
        text: "text",
        search: true,
        multiple: false,
        url: "",
        param: [],
        selectvalue: "",
        change: null
    };
    var options = $.extend(defaults, options);
    var $element = $(this);
    if (options.url != "") {
        $.ajax({
            url: options.url,
            data: options.param,
            title: options.title,
            type: "post",
            dataType: "json",
            async: false,
            success: function (data) {
                $.each(data, function (i) {
                    $element.append($("<input type='radio' id='" + options.id + "' name='" + options.id + "' title='" + data[i][options.text] + "'>"));
                    if (data[i][options.id] == options.selectvalue) {
                        $element.append($("<input type='radio' checked='true'>").val(data[i][options.id]).html(data[i][options.text]));
                    }
                });
            }
        });
    } else {
        $element.select2({
            minimumResultsForSearch: -1
        });
    }
}
$.fn.bindEnterEvent = function ($event) {
    var $selector = $(this);
    $.each($selector, function () {
        $(this).unbind("keydown").bind("keydown", function (event) {
            if (event.keyCode == 13) {
                if ($.isFunction($event)) {
                    $event();
                } else {
                    $event.click();
                }
            }
        });
    });
}
$.fn.bindChangeEvent = function ($event) {
    var $selector = $(this);
    $.each($selector, function () {
        $(this).unbind("change").bind("change", function (event) {
            if ($.isFunction($event)) {
                $event();
            } else {
                $event.click();
            }
        })
    });
}
$.fn.authorizeButton = function (url) {
    var urlw = top.$("iframe:visible").attr("src");
    var modules = top.client.permission;
    var module = {};
    var childModules = [];
    for (var i = 0; i < modules.length; i++) {
        if (modules[i].Url != "") {
            if (url == modules[i].Url) {
                module = modules[i];
            }
        }
    }
    for (var i = 0; i < modules.length; i++) {
        if (modules[i].Url != "") {
            if (modules[i].ParentId == module.Id) {
                childModules.push(modules[i]);
            }
        }
    }
    if (childModules.length > 0) {
        var btnclass = new Array("layui-btn-warning", "layui-btn-success", "layui-btn-danger", "layui-btn-normal", "layui-btn-info", "layui-btn-primary", "layui-btn-link", "layui-btn-default", "layui-btn-warm");
        var $toolbar = $(this);
        var _buttons = '';
        $.each(childModules, function (index, item) {
            _buttons += "<div class='layui-inline'><button id='" + item.EnCode + "' onclick='" + item.JsEvent + "' class=\"layui-btn layui-btn-small " + btnclass[index] + "\">";
            _buttons += "   <i class='" + item.Icon + "' aria-hidden='true'></i> " + item.Name + "";
            _buttons += "</button>  </div> ";
        });
        $toolbar.find('#layui-btn-group:last').html(_buttons);
    } else {
        $toolbar.css('height', '50px');
    }
}
$.fn.itsmButton = function (url, status) {
    var urlw = top.$("iframe:visible").attr("src");
    var modules = top.client.permission;
    var module = {};
    var childModules = [];
    for (var i = 0; i < modules.length; i++) {
        if (modules[i].Url != "") {
            if (url == modules[i].Url) {
                module = modules[i];
            }
        }
    }
    for (var i = 0; i < modules.length; i++) {
        if (modules[i].Url != "") {
            if (modules[i].ParentId == module.Id) {
                childModules.push(modules[i]);
            }
        }
    }
    if (childModules.length > 0) {
        var btnclass = new Array("layui-btn-warning", "layui-btn-success", "layui-btn-danger", "layui-btn-normal", "layui-btn-info", "layui-btn-primary", "layui-btn-link", "layui-btn-default", "layui-btn-warm");
        var $toolbar = $(this);
        var _buttons = "";
        $.each(childModules, function (index, item) {
            _buttons += "<button id='" + item.EnCode + "' onclick='" + item.JsEvent + "' class=\"layui-btn " + btnclass[index] + "\">";
            _buttons += "   <i class='" + item.Icon + "'></i> " + item.Name + "";
            _buttons += "</button>";
        });
        $toolbar.find('#layui-btn-group:last').html(_buttons);
    } else {
        $toolbar.css('height', '40px');
    }
}


$.fn.orderButton = function (url) {
    $.ajax({
        url: url,
        type: 'GET',
        dataType: 'json',
        timeout: 1000,
        cache: false,
        success: function (data) { 
            var childModules = [];
            $.each(data, function (index, item) {
                childModules.push(data[index]);
            });

            if (childModules.length > 0) {
                var btnclass = new Array("layui-btn-warning", "layui-btn-success", "layui-btn-danger", "layui-btn-normal", "layui-btn-info", "layui-btn-primary", "layui-btn-link", "layui-btn-default", "layui-btn-warm");

                var $toolbar = $("#toolbar");
                var _buttons = "";
                $.each(childModules, function (index, item) { 
                    _buttons += "<button id='" + item.EnCode + "' onclick='" + item.JsEvent + "' class=\"layui-btn " + btnclass[index] + "\">";
                    _buttons += "   <i class='" + item.Icon + "'></i> " + item.Name + "";
                    _buttons += "</button>";
                });
                $toolbar.find('#layui-btn-group:last').html(_buttons);
            } else {
                $toolbar.css('height', '40px');
            }

        }
    })
}
$.fn.gridSelectedRowValue = function () {
    var $selectedRows = $(this).children('tbody').find("input[type=checkbox]:checked");
    var result = [];
    if ($selectedRows.length > 0) {
        for (var i = 0; i < $selectedRows.length; i++) {
            result.push($selectedRows[i].value);
        }
    }
    return result;
}
$.fn.formSerialize = function (formdate, callback) {
    var $form = $(this);
    if (!!formdate) {
        for (var key in formdate) {
            var $field = $form.find("[name=" + key + "]");
            if ($field.length == 0) {
                continue;
            }
            var value = $.trim(formdate[key]);
            var type = $field.attr('type');
            if ($field.hasClass('select2')) {
                type = "select2";
            }
            switch (type) {
                case "checkbox":
                    value == "true" ? $field.attr("checked", 'checked') : $field.removeAttr("checked");
                    break;
                case "select2":
                    if (!$field[0].multiple) {
                        $field.select2().val(value).trigger("change");
                    } else {
                        var values = value.split(',');
                        $field.select2().val(values).trigger("change");
                    }
                    break;
                case "radio":
                    $field.each(function (index, $item) {
                        if ($item.value == value) {
                            $item.checked = true;
                        }
                    });
                    break;
                default:
                    $field.val(value);
                    break;
            }

        };
        // 特殊的表单字段可以在回调函数中手动赋值。
        if (callback && $.isFunction(callback)) {
            callback(formdate);
        }
        return false;
    }
    var postdata = {};
    $form.find('input,select,textarea').each(function (r) {
        var $this = $(this);
        var id = $this.attr('id');
        var type = $this.attr('type');
        switch (type) {
            case "checkbox":
                postdata[id] = $this.is(":checked");
                break;
            default:
                var value = $this.val() == "" ? "&nbsp;" : $this.val();
                if (!$.getQueryString("id")) {
                    value = value.replace(/&nbsp;/g, '');
                }
                postdata[id] = value;
                break;
        }
    });
    //if ($('[name=__RequestVerificationToken]').length > 0) {
    //    postdata["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
    //}
    return postdata;
}
$.fn.jdate = function () {
    var date = {
        minDate: '2017-09-01 23:59:59',
        ishmsVal: false,
        isinitVal: true,
        format: "YYYY-MM-DD",
        initAddVal: [0],
        maxDate: $.nowDate(2200)
    };
    $(this).jeDate(date);
}
$.formSubmit = function (options) {
    var defaults = {
        url: "",
        data: {},
        type: "post",
        async: false,
        success: null,
        close: true,
        showMsg: true
    };
    var options = $.extend(defaults, options);
    $.ajax({
        url: options.url,
        data: options.data,
        type: options.type,
        async: options.async,
        dataType: "json",
        success: function (data) {
            if (options.success && $.isFunction(options.success)) {
                options.success(data);
            }
            if (options.close) {
                $.layerClose();
            }
            if (options.showMsg) {
                $.layerMsg(data.message, data.state);
            }
        },
        error: function (xhr, status, error) {
            $.layerMsg('系统错误：' + error, "error");
            $.layerClose();
        },
        beforeSend: function () {

        },
        complete: function () {

        }
    });
}
$.reload = function () {
    location.reload();
    return false;
}
$.currentWindow = function () {
    return top.frames['KLY_iframe'];
}
$.loading = function (bool, text) {
    var $loadingpage = $("#loadingPage");
    var $loadingtext = $loadingpage.find('.loading-content');
    if (bool) {
        $loadingpage.show();
    } else {
        if ($loadingtext.attr('istableloading') == undefined) {
            $loadingpage.hide();
        }
    }
    if (!!text) {
        $loadingtext.html(text);
    } else {
        $loadingtext.html("数据加载中，请稍后…");
    }
    $loadingtext.css("left", (top.$('body').width() - $loadingtext.width()) / 2 - 50);
    $loadingtext.css("top", ($(window).height() - $loadingtext.height()) / 2);
}

$.download = function (url, data, method) {
    if (url && data) {
        data = typeof data == 'string' ? data : jQuery.param(data);
        var inputs = '';
        $.each(data.split('&'), function () {
            var pair = this.split('=');
            inputs += '<input type="hidden" name="' + pair[0] + '" value="' + pair[1] + '" />';
        });
        $('<form action="' + url + '" method="' + (method || 'post') + '">' + inputs + '</form>').appendTo('body').submit().remove();
    }
    else {
        return false;
    };
};

$.getQueryString = function (name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}


$.request = function (name) {
    var search = location.search.slice(1);
    var arr = search.split("&");
    for (var i = 0; i < arr.length; i++) {
        var ar = arr[i].split("=");
        if (ar[0] == name) {
            if (unescape(ar[1]) == 'undefined') {
                return "";
            } else {
                return unescape(ar[1]);
            }
        }
    }
    return "";
}

$.buttonFree = function (options) {
    var defaults = {
        id: "add",
        title: "创建",
        content: "",
    };
    var options = $.extend(defaults, options);
    $.layerOpen({
        id: options.id,
        title: options.title,
        width: options.width,
        height: options.height,
        content: options.content,
        yes: function (iBody) {
            iBody.find('#btnSubmit').click();
            location.reload();
        },
        success: function (layero, index) {
            layer.close(index);
        }, error: function (layero, index) {
            layer.close(index);
        }, end: function () {
            location.reload();
        }
    });
}
$.buttonAdd = function (options) {
    var defaults = {
        id: "add",
        title: "创建",
        content: "",
    };
    var options = $.extend(defaults, options);
    $.layerOpen({
        id: options.id,
        title: options.title,
        content: options.content,
        yes: function (iBody) {
            iBody.find('#btnSubmit').click();
            $(".layui-laypage-btn")[0].click();
            $.fn.zTree.init($("#treeItem"), setting);
        },
        success: function (layero, index) {
            layer.close(index);
        }, error: function (layero, index) {
            layer.close(index);
        }
    });
}
$.buttonEdit = function (options) {
    var checkStatus = table.checkStatus('gridList')
    , data = checkStatus.data;
    if (data.length != 1) {
        $.layerMsg("请勾选单条数据", "warning");
        return;
    }
    var defaults = {
        id: "edit",
        title: "修改",
        content: "",
        key: data[0].Id,
        ciGroupId: null,
        callback: null
    };
    var options = $.extend(defaults, options);
    var opt = options.content + "?primaryKey=" + options.key;
    if (options.ciGroupId != null) {
        opt = options.content + "?primaryKey=" + options.key + "&ciGroupId=" + options.ciGroupId;
    }
    $.layerOpen({
        title: options.title,
        content: opt,
        error: function (xhr, status, error) {
            $.layerMsg(error, "error");
        },
        yes: function (layero, index) {
            layero.find('#btnSubmit').click();
            $(".layui-laypage-btn")[0].click();
            $.fn.zTree.init($("#treeItem"), setting);
        },
        success: function (layero, index) {
            // iBody.find('#btnSubmit').click(); 
            // $(".layui-laypage-btn")[0].click();
            layer.close(index);
        }, error: function (layero, index) {
            layer.close(index);
        }
    });
}
$.buttonDetail = function (options) {
    var checkStatus = table.checkStatus('gridList')
    , data = checkStatus.data;
    if (data.length != 1) {
        $.layerMsg("请勾选单条数据", "warning");
        return;
    }
    var defaults = {
        id: "detail",
        title: "查看",
        content: "",
        key: data[0].Id,
        ciGroupId: null,
        callback: null
    };
    var options = $.extend(defaults, options);
    var opt = options.content + "?id=" + options.key;
    if (options.ciGroupId != null) {
        opt = options.content + "?id=" + options.key + "&ciGroupId=" + options.ciGroupId;
    }
    $.layerOpen({
        title: options.title,
        content: opt,
        error: function (xhr, status, error) {
            $.layerMsg(error, "error");
        },
        yes: function (layero, index) {
        },
        success: function (layero, index) {
            layer.close(index);
        }, error: function (layero, index) {
            layer.close(index);
        }
    });
}
$.buttonChk = function (options) {
    var checkStatus = table.checkStatus('gridList')
          , data = checkStatus.data;
    if (data.length < 1) {
        $.layerMsg("请勾选数据", "warning");
        return;
    }
    var strKey = "";
    for (var i = 0; i < data.length; i++) {
        strKey += data[i].Id + ',';
    }
    var defaults = {
        id: "chk",
        url: "",
        key: strKey,
        callback: null
    };
    var options = $.extend(defaults, options);
    $.layerConfirm({
        content: "您已选中" + data.length + "条数据, 确定操作吗？",
        callback: function () {
            $.formSubmit({
                url: options.url,
                data: { primaryKey: options.key },
                success: function () {
                    $(".layui-laypage-btn")[0].click();
                    $.fn.zTree.init($("#treeItem"), setting);
                }
            });
        }
    });
}

$.buttonChkNoTable = function (options) {
    var strKey = "";
    var defaults = {
        id: "chk",
        url: "",
        key: strKey,
        callback: null
    };
    var options = $.extend(defaults, options);
    $.layerConfirm({
        content: "您确定操作吗？",
        callback: function () {
            $.formSubmit({
                url: options.url,
                data: { primaryKey: options.key },
                success: function () {
                    location.reload();
                }
            });
        }
    });
}

$.buttonOrder = function (options) {
    var checkStatus = table.checkStatus('gridList')
    , data = checkStatus.data;
    if (data.length != 1) {
        $.layerMsg("请勾选单条数据", "warning");
        return;
    }
    var defaults = {
        id: "edit",
        title: "工单",
        content: "",
        key: data[0].OrderId,
        ciGroupId: null,
        callback: null
    };
    var options = $.extend(defaults, options);
    var opt = options.content + "?primaryKey=" + options.key;

    $.layerOpen({
        title: options.title,
        width: options.width,
        height: options.height,
        content: opt,
        error: function (xhr, status, error) {
            $.layerMsg(error, "error");
        },
        yes: function (layero, index) {
            layero.find('#btnSubmit').click();
            $(".layui-laypage-btn")[0].click();
            $.fn.zTree.init($("#treeItem"), setting);
        },
        success: function (layero, index) {
            // iBody.find('#btnSubmit').click(); 
            // $(".layui-laypage-btn")[0].click();
            layer.close(index);
        }, error: function (layero, index) {
            layer.close(index);
        }
    });
}
$.buttonExport = function (options) {
    var checkStatus = table.checkStatus('gridList')
    , data = checkStatus.data;
    var msg;
    if (data.length < 1) {
        msg = "您选择导出全部数据， 确定导出吗";
    }
    else {
        msg = "您已选中" + data.length + "条数据, 确定导出吗？";
    }
    var strKey = "";
    for (var i = 0; i < data.length; i++) {
        strKey += data[i].Id + ',';
    }
    var defaults = {
        id: "chk",
        url: "",
        key: strKey,
        callback: null
    };
    var options = $.extend(defaults, options);
    $.layerConfirm({
        title: "导出数据",
        content: msg,
        callback: function (r) {
            $.download(options.url, "primaryKey=" + options.key, 'post');
            $(".layui-laypage-btn")[0].click();
        }
    });

}