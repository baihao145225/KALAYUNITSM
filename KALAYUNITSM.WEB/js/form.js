layui.define(['form'], function (exports) {
    var form = layui.form, layedit = layui.layedit;
    var layer = layui.layer;

    //创建一个编辑器
    var editIndex = layedit.build('LAY_demo_editor');
    //自定义验证规则
    form.verify({
        title: function (value) {
            if (value.length < 5) {
                return '标题至少得5个字符啊';
            }
        }
      , pass: function (value, item) {
          if (item.title != 'edit') {
              if (value.length < 5) {
                  return '密码必须6到12位且不能出现空格';
              }
          }

      }
      , content: function (value) {
          layedit.sync(editIndex);
      },
        username: function (value) {
            if (!new RegExp("^[a-zA-Z0-9_\u4e00-\u9fa5\\s·]+$").test(value)) {
                return '用户名不能有特殊字符';
            }
            if (/(^\_)|(\__)|(\_+$)/.test(value)) {
                return '用户名首尾不能出现下划线\'_\'';
            }
            if (/^\d+\d+\d$/.test(value)) {
                return '用户名不能全为数字';
            }
        }
    });

});

