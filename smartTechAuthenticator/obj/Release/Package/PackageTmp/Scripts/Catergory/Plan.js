

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
                    return "<a href='/Plans/PlanDetails?Id=" + row.Id + "' class='btn btn-info' >Edit</a>";
                }
            },
            {
                data: null, render: function (data, type, row) {
                    // return "<button class='btn btn-danger btn-delete'   data-id='" + row.Id + "'  data-isActive='" + row.IsActive + "'  >Delete</button>";

                    return "<button class='btn btn-danger btn-delete'   data-id='" + row.Id + "'>Delete</button>";

                }
            },
            {
                data: null, render: function (data, type, row) {
                    return "<a href='ViewPlans?Id=" + row.Id + "' class='btn btn-info' >View</a>";
                }
            },

        ]
    });

    $(document).on("click", ".btn-delete", function () {
        if (confirm("Are you sure, you want to delete?")) {
            var Id = $(this).attr("data-id");
            var Category =
            {
                Id: Id
            }
            $.ajax({
                type: "POST",
                url: "/Plans/DeletePlans",
                data: Category,
                success: function (response) {
                    if (response.Status == 1) {
                        tbl_Customer.ajax.reload();
                        showMessage("Success", "Plan deleted successfully");
                    } else {
                        showMessage("Failed", "Plan not deleted successfully,Please delete all references.",);
                    }
                },
                error: function () {
                    showMessage("Failed", "Plan not deleted successfully",);
                }
            });
        }
    });
});