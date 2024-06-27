

$(document).ready(function () {
    var tbl_Customer = $("#tbl_Category").DataTable({
        "processing": true, // for show progress bar  
        "serverSide": true, // for process server side  
        "filter": true, // this is for disable filter (search box)  
        "orderMulti": false, // for disable multiple column at once  
        "pageLength": 4,

        "ajax": {
            "url": "/Plans/GetPlans",
            "type": "POST",
            "datatype": "json"
        },

        "columns": [
            {
                "render": function (row, data, index, meta) {
                    return meta.row + 1;
                }
            },
            { "data": "PlanName", "name": "PlanName", "autoWidth": true },
            { "data": "Price", "name": "Price", "autoWidth": true },
            { "data": "Validity", "name": "Validity", "autoWidth": true },

           
            
            {
                data: null, render: function (data, type, row) {
                    return "<a href='ViewPlans?Id=" + row.Id + "' class='btn btn-info' >View</a>";
                }
            },

            {
                data: null, render: function (data, type, row) {
                    return "<a href='ViewPurchasePage?Id=" + row.Id + "' class='btn btn-info' >Purchase</a>";
                }
            },

        ]
    });
});