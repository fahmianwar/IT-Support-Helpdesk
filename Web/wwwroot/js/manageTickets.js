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
                "data": "startDateTime",
                render: function (data, type, row) {
                    if (data) {
                        var m = data.split(/[T-]/);
                        var d = new Date(parseInt(m[0]), parseInt(m[1]) - 1, parseInt(m[2]));
                        var curr_date = d.getDate();
                        var curr_month = d.getMonth() + 1
                        var curr_year = d.getFullYear();
                        var formatedDate = d.getDate() + '-' + d.getMonth() + '-' + d.getFullYear();
                        return formatedDate;
                    }
                    else
                        return data
                },
            },
            {
                "data": "level"
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row['userName'] + ' ' + '#' + row['userId'];
                }
            },
            {
                "render": function (data, type, row) {
                    if (row['priorityName'] == "Low") {
                        return `<span class="right badge badge-info">${row['priorityName']}</span>`;
                    } else if (row['priorityName'] == "Medium") {
                        return `<span class="right badge badge-warning">${row['priorityName']}</span>`;
                    } else if (row['priorityName'] == "High") {
                        return `<span class="right badge badge-danger">${row['priorityName']}</span>`;
                    } else {
                        return `<span class="right badge badge-primary">${row['priorityName']}</span>`;
                    }
                }
            },
            {
                "data": "categoryName"
            },
            {
                "render": function (data, type, row) {
                    if (row['endDateTime'] == null) {
                        if (row['level'] == viewBagLevel) {
                            return `<button type="button" class="btn btn-outline-info" onclick="askNextLevel('${row['id']}')"  data-placement="bottom" title="Ask Next Level to Help"><i class="fas fa-question"></i></button> <button type="button" class="btn btn-outline-primary" onclick="viewConvertation('${row['id']}')" data-toggle="modal" data-target="#viewConvertationModal"  data-placement="bottom" title="Chatting With Client"><i class="fas fa-comment"></i></button> <button type="button" class="btn btn-outline-danger" onclick="closeTicket('${row['id']}','${viewBagUserId}')"  data-placement="bottom" title="Close Ticket"><i class="fas fa-times"></i></button> <button type="button" class="btn btn-outline-warning" onclick="viewPriority('${row['id']}')" data-toggle="modal" data-target="#viewPriorityModal" data-placement="bottom" title="Change Priority Ticket"><i class="fas fa-level-up-alt"></i></button>`;
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
                        var m = data.split(/[T-]/);
                        var d = new Date(parseInt(m[0]), parseInt(m[1]) - 1, parseInt(m[2]));
                        var curr_date = d.getDate();
                        var curr_month = d.getMonth() + 1
                        var curr_year = d.getFullYear();
                        var formatedDate = d.getDate() + ' - ' + d.getMonth() + ' - ' + d.getFullYear();
                        return formatedDate;
                    }
                    else
                        return data
                },
            },
            {
                "data": "level"
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row['userName'] + ' ' + '#' + row['userId'];
                }
            },
            {
                "render": function (data, type, row) {
                    if (row['priorityName'] == "Low") {
                        return `<span class="right badge badge-info">${row['priorityName']}</span>`;
                    } else if (row['priorityName'] == "Medium") {
                        return `<span class="right badge badge-warning">${row['priorityName']}</span>`;
                    } else if (row['priorityName'] == "High") {
                        return `<span class="right badge badge-danger">${row['priorityName']}</span>`;
                    } else {
                        return `<span class="right badge badge-primary">${row['priorityName']}</span>`;
                    }
                }
            },
            {
                "data": "categoryName"
            },
            {
                "render": function (data, type, row) {
                    if (row['staffId'] == null) {
                        return `<button type="button" class="btn btn-outline-primary" onclick="handleTicket('${row['id']}','${userId}')"><i class="fas fa-check"  data-placement="bottom" title="Handle Ticket"></i></button>`;
                    } else {
                        return `<span class="right badge badge-info">Handle by Staff # ${row['staffId']}</span>`;
                    }
                }
            }
        ]
    });

    $('#tableViewHistoryTickets').DataTable({
        ajax: {
            url: 'https://localhost:44357/Panel/GetHistoryHandleTickets',
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
                        var m = data.split(/[T-]/);
                        var d = new Date(parseInt(m[0]), parseInt(m[1]) - 1, parseInt(m[2]));
                        var curr_date = d.getDate();
                        var curr_month = d.getMonth() + 1
                        var curr_year = d.getFullYear();
                        var formatedDate = d.getDate() + '-' + d.getMonth() + '-' + d.getFullYear();
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
                        var m = data.split(/[T-]/);
                        var d = new Date(parseInt(m[0]), parseInt(m[1]) - 1, parseInt(m[2]));
                        var curr_date = d.getDate();
                        var curr_month = d.getMonth() + 1
                        var curr_year = d.getFullYear();
                        var formatedDate = d.getDate() + '-' + d.getMonth() + '-' + d.getFullYear();
                        return formatedDate;
                    }
                    else
                        return data
                },
            },
            {
                "data": "level"
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row['userName'] + ' ' + '#' + row['userId'];
                }
            },
            {
                "render": function (data, type, row) {
                    if (row['priorityName'] == "Low") {
                        return `<span class="right badge badge-info">${row['priorityName']}</span>`;
                    } else if (row['priorityName'] == "Low") {
                        return `<span class="right badge badge-warning">${row['priorityName']}</span>`;
                    } else if (row['priorityName'] == "High") {
                        return `<span class="right badge badge-danger">${row['priorityName']}</span>`;
                    } else {
                        return `<span class="right badge badge-info">${row['priorityName']}</span>`;
                    }
                }
            },
            {
                "data": "categoryName"
            },
            {
                "data": "review",
                render: function (data, type, row) {
                    if (row['review'] == 0) {
                        return '-';
                    }
                    else if (row['review'] == 1) {
                        return '&#11088';
                    }
                    else if (row['review'] == 2) {
                        return '&#11088' + '&#11088';
                    }
                    else if (row['review'] == 3) {
                        return '&#11088' + '&#11088' + '&#11088';
                    }
                    else if (row['review'] == 4) {
                        return '&#11088' + '&#11088' + '&#11088' + '&#11088';
                    }
                    else if (row['review'] == 5) {
                        return '&#11088' + '&#11088' + '&#11088' + '&#11088' + '&#11088';
                    }
                }
            },
            {
                "render": function (data, type, row) {
                    if (row['endDateTime'] == null) {
                        if (row['level'] == viewBagLevel) {
                            return `<button type="button" class="btn btn-outline-info" onclick="askNextLevel('${row['id']}')"  data-placement="bottom" title="Ask Next Level to Help"><i class="fas fa-question"></i></button> | <button type="button" class="btn btn-outline-primary" onclick="viewConvertation('${row['id']}')" data-toggle="modal" data-target="#viewConvertationModal"  data-placement="bottom" title="Chatting With Client"><i class="fas fa-comment"></i></button> | <button type="button" class="btn btn-outline-danger" onclick="closeTicket('${row['id']}','${viewBagUserId}')"  data-placement="bottom" title="Close Ticket"><i class="fas fa-times"></i></button>`;
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

function openPriorityTicket() {
    $.ajax({
        url: 'https://localhost:44381/api/Priorities/'
    }).done((result) => {
        text = "";
        $.each(result, function (key, val) {
            text += `<option value="${val.id}">${val.name}</option>`;
        });
        $("#inputPriority").html(text);
    }).fail((error) => {
        console.log(error);
    });
}

function viewPriority(caseId) {
    openPriorityTicket();
    $("#inputPriorityCaseId").val(parseInt(caseId));
}

function editPriority() {
    var obj = new Object();
    obj.PriorityId = parseInt($("#inputPriority").val());
    obj.CaseId = parseInt($("#inputPriorityCaseId").val());
    obj.UserId = parseInt(viewBagUserId);
    console.log(obj);
    //console.log(JSON.stringify(obj));
    if (obj.UserId < 0 || obj.CaseId < 0 || obj.Message == "") {
        Swal.fire({
            title: 'Error!',
            text: 'Failed change priority',
            icon: 'error',
            confirmButtonText: 'OK'
        });
    } else {
        $.ajax({
            url: 'https://localhost:44381/api/Cases/ChangePriority',
            type: "POST",
            dataType: "json",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            data: JSON.stringify(obj)
        }).done((result) => {
            //alert(result);
            $('#tableViewHandleTickets').DataTable().ajax.reload();
            $('#viewPriorityModal').modal('hide');
        }).fail((error) => {
            //alert(error);
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
                            <span class="direct-chat-name float-right">${val.userName}</span>
                            <span class="direct-chat-timestamp float-left">${val.dateTime}</span>
                        </div>
                        <img class="direct-chat-img" src="https://localhost:44381/api/Users/Avatar/${val.userId}" alt="${val.userName}">
                        <div class="direct-chat-text">
                            ${val.message}
                        </div>
                    </div>
                    `;
            } else {
                text += `
                    <div class="direct-chat-msg">
                        <div class="direct-chat-infos clearfix">
                            <span class="direct-chat-name float-left">${val.userName} #${val.userId}</span>
                            <span class="direct-chat-timestamp float-right">${val.dateTime}</span>
                        </div>
                        <img class="direct-chat-img" src="https://localhost:44381/api/Users/Avatar/${val.userId}" alt="${val.userName}">
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

            $("#inputConvertationMessage").summernote('reset');
            $('#tableViewHandleTickets').DataTable().ajax.reload();
            viewChat(obj.CaseId);
            $('#viewconvertationmodal').modal('hide');
            //Swal.fire({
            //    title: 'Success!',
            //    text: 'Berhasil menambahkan data',
            //    icon: 'success',
            //    confirmButtonText: 'Cool'
            //});
            //$('#tableProfiles').DataTable().ajax.reload();
            //console.log(result);

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