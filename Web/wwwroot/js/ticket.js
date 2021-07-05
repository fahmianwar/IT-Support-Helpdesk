$(document).ready(function () {
    $('#inputConvertationMessage').summernote();
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
                "data": "level",
                render: function (data, type, row) {
                    if (row['level'] == 1) {
                        return 'Case Handle by Customer Service';
                    }
                    else if (row['level'] == 2) {
                        return 'Case Handle by IT Support';
                    }
                    else if (row['level'] == 3) {
                        return 'Case Handle By Software Developer';
                    }
                }
            },
            {
                "data": "userId"
            },
            {
                "data": "priorityName"
            },
            {
                "data": "categoryName"
            },
            {
                "render": function (data, type, row) {
                    if (row['endDateTime'] == null) {
                        return `<button type="button" class="btn btn-primary" onclick="viewConvertation('${row['id']}')" data-toggle="modal" data-target="#viewConvertationModal">Chat</button>`;
                    } else {
                        return "-";
                    }
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
            dataType: "json",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            data: JSON.stringify(obj)
        }).done((result) => {
            //alert(result);
            Swal.fire({
                title: 'Success!',
                text: 'Berhasil menambahkan data',
                icon: 'success',
                confirmButtonText: 'Cool'
            });
            //$('#tableProfiles').DataTable().ajax.reload();
            //console.log(result);
            $('#tableUsers').DataTable().ajax.reload();
            $('#createModal').modal('toggle');
        }).fail((error) => {
            //alert(error);
            Swal.fire({
                title: 'Error!',
                text: 'Gagal menambahkan data',
                icon: 'error',
                confirmButtonText: 'Cool'
            });
            //console.log(error);
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
            if (val.userId == viewBagUserId) {
                text += `
                    <div class="direct-chat-msg right">
                        <div class="direct-chat-infos clearfix">
                            <span class="direct-chat-name float-right">${val.userName}</span>
                            <span class="direct-chat-timestamp float-left">${val.dateTime}</span>
                        </div>
                        <img class="direct-chat-img" src="https://localhost:44381/api/Users/Avatar/${val.avatar}" alt="${val.userName}">
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
                        <img class="direct-chat-img" src="https://localhost:44381/api/Users/Avatar/${val.avatar}" alt="${val.userName}">
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
          
            //$("#inputConvertationMessage").val('');
            //Swal.fire({
            //    title: 'Success!',
            //    text: 'Berhasil menambahkan data',
            //    icon: 'success',
            //    confirmButtonText: 'Cool'
            //});
            //$('#tableProfiles').DataTable().ajax.reload();
            //console.log(result);
            viewChat(obj.CaseId);
            $('#tableTickets').DataTable().ajax.reload();
            $("#inputConvertationMessage").summernote('reset');
            $('#viewConvertationModal').modal('hide');
        }).fail((error) => {
            alert(error);
            Swal.fire({
                title: 'Error!',
                text: 'Gagal menambahkan data',
                icon: 'error',
                confirmButtonText: 'OK'
            });
            console.log(error);
        });
    }
}