$(document).ready(function () {
    $('#inputConvertationMessage').summernote();
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
                    if (row['endDateTime'] == null) {
                        if (row['level'] == viewBagLevel) {
                            return `<button type="button" class="btn btn-info" onclick="askNextLevel('${row['id']}')">Ask Help</button> | <button type="button" class="btn btn-primary" onclick="viewConvertation('${row['id']}')" data-toggle="modal" data-target="#viewConvertationModal">chat</button> | <button type="button" class="btn btn-danger" onclick="closeTicket('${row['id']}','${viewBagUserId}')">Close</button>`;
                        } else {
                            return null;
                        }
                        //return `<button type="button" class="btn btn-info" onclick="asknextlevel('${row['id']}')">ask next level</button> | <button type="button" class="btn btn-primary" onclick="viewconvertation('${row['id']}')" data-toggle="modal" data-target="#viewconvertationmodal">chat</button> | <button type="button" class="btn btn-danger" onclick="closeticket('${row['id']}','${userid}')">close</button>`;
                    } else {
                        return null;
                    }
                }
            }
        ]
    });

});


function viewConvertation(caseId) {
    $("#inputConvertationCaseId").val(parseInt(caseId));
    viewChat(caseId);
}

function viewChat(caseId) {
    $.ajax({
        url: 'https://localhost:44381/api/Convertations/ViewConvertationsByCaseId/' + caseId
    }).done((result) => {
        text = "";
        $.each(result, function (key, val) {
            console.log(val.userId);
            console.log(viewBagUserId);
            if (val.userId == parseInt(viewBagUserId)) {
                text += `
                    <div class="direct-chat-msg right">
                        <div class="direct-chat-infos clearfix">
                            <span class="direct-chat-name float-right">${viewBagName}</span>
                            <span class="direct-chat-timestamp float-left">${val.dateTime}</span>
                        </div>
                        <img class="direct-chat-img" src="/lib/adminlte/img/user1-128x128.jpg" alt="Profile">
                        <div class="direct-chat-text">
                            ${val.message}
                        </div>
                    </div>
                    `;
            } else {
                text += `
                    <div class="direct-chat-msg">
                        <div class="direct-chat-infos clearfix">
                            <span class="direct-chat-name float-left">Client #${val.userId}</span>
                            <span class="direct-chat-timestamp float-right">${val.dateTime}</span>
                        </div>
                        <img class="direct-chat-img" src="/lib/adminlte/img/user1-128x128.jpg" alt="Profile">
                        <div class="direct-chat-text">
                            ${val.message}
                        </div>
                    </div>
                    `;
            }

        });
        $("#chatMessages").html(text);
    }).fail((error) => {
        console.log(error);
    });
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
            viewChat(obj.CaseId);
            $("#inputConvertationMessage").val("");
            //Swal.fire({
            //    title: 'Success!',
            //    text: 'Berhasil menambahkan data',
            //    icon: 'success',
            //    confirmButtonText: 'Cool'
            //});
            //$('#tableProfiles').DataTable().ajax.reload();
            //console.log(result);
            $('#tableViewHandleTickets').DataTable().ajax.reload();
            $("#inputConvertationMessage").val('');
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
        text: 'Apakan Anda yakin untuk menutup CaseId #' + caseId + ' oleh StaffId #' + userId + ' ?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Ya',
        cancelButtonText: 'Tidak'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: 'https://localhost:44381/api/Cases/CloseTicket',
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
                $('#tableViewHandleTickets').DataTable().ajax.reload();
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


function askNextLevel(caseId) {
    var obj = new Object();
    obj.CaseId = parseInt(caseId);
    Swal.fire({
        title: 'Konfirmasi Meminta Bantuan Ticket',
        text: 'Apakan Anda yakin meminta bantuan ke Level selanjutnya untuk CaseId #' + caseId + ' oleh StaffId #' + viewBagUserId + ' ?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Ya',
        cancelButtonText: 'Tidak'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: 'https://localhost:44381/api/Cases/AskNextLevel',
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
                $('#tableViewHandleTickets').DataTable().ajax.reload();
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