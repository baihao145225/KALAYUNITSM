layui.define(['table'], function (exports) {
    var table = layui.table;
    var options = {
        loading: true,
        initSort: { field: 'SortCode', type: 'desc' },
        skin: 'row',
        size: 'sm', //小尺寸的表格
        even: true,
        page: true,
        limits: [10, 20, 50, 100],
        limit: 10,
        done: function (res, curr, count) {
            _curr = curr;
            _count = count;
            //if (res.data.length == 0) { //不分页时使用
            if (count == 0) {
                $(".layui-table-view").hide();
            }
        },
        request: {
            pageName: 'curr'
    , limitName: 'nums'
        }
    };
    table.set(options);
});