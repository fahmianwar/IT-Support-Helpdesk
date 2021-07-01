$(document).ready(function () {
    $('#tableViewHandleTickets').DataTable({
        ajax: {
            url: 'https://localhost:44357/Panel/GetHandleTickets',
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
                    return `<button type="button" class="btn btn-primary" onclick="viewConvertation('${row['id']}')" data-toggle="modal" data-target="#viewConvertationModal">Chat</button> | <button type="button" class="btn btn-primary" onclick="closeTicket('${row['id']}','3')">Close</button>`;
                }
            }
        ]
    });

});


function viewConvertation(caseId) {
    $("#inputConvertationCaseId").val(parseInt(caseId));
}

function createConvertation() {
    var obj = new Object();
    obj.UserId = parseInt($("#inputConvertationUserId").val());
    obj.CaseId = parseInt($("#inputConvertationCaseId").val());
    obj.Message = $("#inputConvertationMessage").val();
    console.log(obj);
    //console.log(JSON.stringify(obj));
    if (obj.UserId < 0 || obj.CaseId < 0 || obj.Message == "") {
        Swal.fire({
            title: 'Error!',
            text: 'Failed create user',
            icon: 'error',
            confirmButtonText: 'OK'
        });
    } else {
        $.ajax({
            url: 'https://localhost:44381/api/Convertations/CreateConvertations',
            type: "POST",
            dataType: "json",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            data: JSON.stringify(obj)
        }).done((result) => {
            //alert(result);
            text = `<h1>Reload</h1>`;
            $("#chatMessages").html(text);
            $("#inputConvertationMessage").reset();
            Swal.fire({
                title: 'Success!',
                text: 'Berhasil menambahkan data',
                icon: 'success',
                confirmButtonText: 'Cool'
            });
            //$('#tableProfiles').DataTable().ajax.reload();
            //console.log(result);
            $('#tableUsers').DataTable().ajax.reload();
            $("#inputConvertationMessage").reset();
            $('#viewConvertationModal').modal().hide();
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


function closeTicket(caseId, userId) {
    var obj = new Object();
    obj.CaseId = parseInt(caseId);
    obj.UserId = parseInt(userId);
    Swal.fire({
        title: 'Konfirmasi Penutupan Ticket',
        text: 'Apakan Anda yakin untuk menutup CaseId #' + caseId + 'oleh StaffId #' + userId + ' ?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Ya',
        cancelButtonText: 'Tidak'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: 'https://localhost:44357/api/Cases/HandleTicket',
                type: "POST",
                dataType: "json",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                data: JSON.stringify(obj)
            }).done((result) => {
                console.log(result);
                console.log(obj);
                $('#tableViewTickets').DataTable().ajax.reload();
                Swal.fire({
                    title: 'Success!',
                    text: 'Berhasil menambahkan Case untuk ditangani Anda',
                    icon: 'success',
                    confirmButtonText: 'Oke'
                });
            }).fail((error) => {
                console.log(error);
                console.log(obj);
                Swal.fire({
                    title: 'Error!',
                    text: 'Gagal menambahkan Case untuk ditangani Anda',
                    icon: 'error',
                    confirmButtonText: 'Oke'
                });
            });
        }
    });

}