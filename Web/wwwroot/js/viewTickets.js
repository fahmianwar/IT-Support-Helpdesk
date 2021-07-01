$(document).ready(function () {
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
                    // UserId belum masuk kedalam handleTicket function
                    return `<button type="button" class="btn btn-primary" onclick="handleTicket('${row['id']}','3')">Handle</button>`;
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
        text: 'Apakan Anda yakin untuk menangani Case #' + caseId + 'oleh StaffId #'+ userId +' ?',
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