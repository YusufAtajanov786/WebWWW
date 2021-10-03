var dataTable;
$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $("#DT_load").DataTable({
        "ajax": {
            "url": "/api/user",
            "type": "GET",
            "dataType": "json"
        },
        "columns": [
            { "data": "fullName", "width": "25%" },
            { "data": "email", "width": "25%" },
            { "data": "phoneNumber", "width": "25%" },
            {
                "data": {id:"id", lockoutEnd:"lockoutEnd"},
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    if (lockout > today) {
                        return `<div class="text-center" >
                        <a  class="btn btn-danger text-white" style="cursor:pointer;width:100px;" onclick=LockUnlock('${data.id}')>
                            <i class="far fa-trash>Unlock</i>
                        </a></div>`;
                    } else {
                        return `<div class="text-center" >
                        <a  class="btn btn-success text-white" style="cursor:pointer;width:100px;" onclick=LockUnlock('${data.id}')>
                            <i class="far fa-trash>Lock</i>
                        </a></div>`;
                    }


                },
                "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}


function LockUnlock(id)  {
  
            $.ajax({
                type: "POST",
                url: '/api/User',
                data: JSON.stringify(id),
                contentType:"application/json",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message)
                    }
                }
            });
    
}