layui.define(['table'], function (exports) {
    var table = layui.table;
    var options = {
        loading: true,
        initSort: { field: 'SortCode', type: 'desc' },
        skin: 'row',
        size: 'sm', //С�ߴ�ı��
        even: true,
        page: true,
        limits: [10, 20, 50, 100],
        limit: 10,
        done: function (res, curr, count) {
            _curr = curr;
            _count = count;
            //if (res.data.length == 0) { //����ҳʱʹ��
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