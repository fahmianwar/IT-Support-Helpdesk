$(document).ready(function () {
    $('#tableTickets').DataTable({
        ajax: {
            url: 'https://localhost:44357/Panel/GetTickets',
            dataSrc: ''
        },
        columns: [

            {
                "data": null, "sortable": false,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "description"
            },
            {
                "data": "startDateTime"
            },
            {
                "data": "endDateTime"
            },
            {
                "data": "review"
            },
            {
                "data": "level"
            },
            {
                "data": "userId"
            },
            {
                "data": "priorityId"
            },
            {
                "data": "categoryId"
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-primary" onclick="detailCases('${row['id']}')" data-bs-toggle="modal" data-bs-target="#detailModal">Detail</button> | <button type="button" class="btn btn-info" onclick="editCase('${row['id']}')" data-bs-toggle="modal" data-bs-target="#editModal">Edit</button> | <button type="button" class="btn btn-danger" onclick="deleteCase('${row['id']}')">Delete</button>`;
                }
            }
        ]
    });

});

function createTicket() {
    var obj = new Object();
    obj.UserId = parseInt($("#inputCreateUserId").val());
    obj.Description = $("#inputCreateDescription").val();
    obj.CategoryId = parseInt($("#inputCreateCategoryId ").val());
    //console.log(obj);
    //console.log(JSON.stringify(obj));
    if (obj.UserId < 0 || obj.Description == "" || obj.CategoryId == "") {
        Swal.fire({
            title: 'Error!',
            text: 'Failed create user',
            icon: 'error',
            confirmButtonText: 'OK'
        });
    } else {
        $.ajax({
            url: 'https://localhost:44381/api/Cases/CreateTicket',
            type: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            data: JSON.stringify(obj)
        }).done((result) => {
            alert(result);
            Swal.fire({
                title: 'Success!',
                text: 'Berhasil menambahkan data',
                icon: 'success',
                confirmButtonText: 'Cool'
            });
            //$('#tableProfiles').DataTable().ajax.reload();
            console.log(result);
            $('#tableUsers').DataTable().ajax.reload();
        }).fail((error) => {
            alert(error);
            Swal.fire({
                title: 'Error!',
                text: 'Gagal menambahkan data',
                icon: 'error',
                confirmButtonText: 'Cool'
            });
            console.log(error);
        });
    }
}