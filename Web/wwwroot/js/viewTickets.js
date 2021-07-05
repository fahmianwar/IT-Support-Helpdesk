﻿$(document).ready(function () {
    $('#tableViewTickets').DataTable({
        ajax: {
            url: 'https://localhost:44357/Panel/GetTicketsByLevel',
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
                "data": "startDateTime",
                render: function (data, type, row) {
                    if (data) {
                        debugger;
                        var m = data.split(/[T-]/);
                        var d = new Date(parseInt(m[0]), parseInt(m[1]) - 1, parseInt(m[2]));
                        var curr_date = d.getDate();
                        var curr_month = d.getMonth() + 1
                        var curr_year = d.getFullYear();
                        var formatedDate = d.getDate() + '.' + d.getMonth() + '.' + d.getFullYear();
                        return formatedDate;
                    }
                    else
                        return data
                },
            },
            {
                "data": "endDateTime",
                render: function (data, type, row) {
                    if (data) {
                        debugger;
                        var m = data.split(/[T-]/);
                        var d = new Date(parseInt(m[0]), parseInt(m[1]) - 1, parseInt(m[2]));
                        var curr_date = d.getDate();
                        var curr_month = d.getMonth() + 1
                        var curr_year = d.getFullYear();
                        var formatedDate = d.getDate() + '.' + d.getMonth() + '.' + d.getFullYear();
                        return formatedDate;
                    }
                    else
                        return data
                },
            },
            {
                "data": "review",
                render: function (data, type, row) {
                    if (row['review'] == 0) {
                        return '-';
                    }
                    else if (row['review'] == 1) {
                        return ':star:';
                    }
                    else if (row['review'] == 2) {
                        return ':star:'+'star:';
                    }
                    else if (row['review'] == 3) {
                        return ':star:' + 'star:' + 'star:';
                    }
                    else if (row['review'] == 4) {
                        return ':star:' + 'star:' + 'star:' + 'star:';
                    }
                    else if (row['review'] == 4) {
                        return ':star:' + 'star:' + 'star:' + 'star:' + 'star:';
                    }
                },
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
                    return `<button type="button" class="btn btn-primary" onclick="handleTicket('${row['id']}','${userId}')">Handle</button>`;
                }
            }
        ]
    });

});

function handleTicket(caseId, userId) {
    var obj = new Object();
    obj.CaseId = parseInt(caseId);
    obj.UserId = parseInt(userId);
    Swal.fire({
        title: 'Konfirmasi Penanganan Data',
        text: 'Apakan Anda yakin untuk menangani Case #' + caseId + 'oleh StaffId #' + userId + ' ?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Ya',
        cancelButtonText: 'Tidak'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: 'https://localhost:44381/api/Cases/HandleTicket',
                type: "POST",
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