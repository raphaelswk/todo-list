$(document).ready(function () {
    $('#btn-new-task').on('click', function () {
        AddTask();
    });

    $('#input-new-task').keypress(function (e) {
        if (e.which == 13) {
            AddTask();
            return false;
        }
    });

    BuildData();
});

function BuildData() {
    $('#table-tasks').dataTable({
        filter: false,
        search: false,
        paging: false,
        info: false,        
        destroy: true,
        ajax: {
            'url': '/UserTask/GetData',
            'type': 'GET',
            'datatype': 'json'
        },
        'columnDefs': [
            {
                render: function (data, type, full, meta) {
                    if (full.Checked === true) {
                        var rowIndex = meta.row + 1;
                        $('#table-tasks tbody tr:nth-child(' + rowIndex + ')').addClass('strikeout');
                        return data;
                    } else {
                        return data;
                    }
                }
            }],
        columns: [
            {
                'data': 'Checked', 'name': 'Checked', 'render': function (data, type, full, meta) {
                    const checkbox = full.Checked === true
                        ? '<input type="checkbox" checked onclick="ChangeState(' + full.Id + ')" />'
                        : '<input type="checkbox" onclick="ChangeState(' + full.Id + ')" />'

                    return checkbox;
                }
            },

            {
                'data': 'Description',
                'createdCell': function (td, cellData, rowData, row, col) {
                    if (rowData.Checked === true) {
                        $(td).addClass('strikeout');
                    }
                }
            },

            {
                'data': 'ModifiedAt', 'name': 'ModifiedAt', 'render': function (data, type, full, meta) {
                    const formattedDate = '<small>' + moment(full.ModifiedAt).format('DD/MM/YYYY hh:mm:ss') + '</small>'
                    return formattedDate;
                }
            },

            {
                'data': 'Id', 'name': 'Id', 'render': function (data, type, full, meta) {
                    return '<button id="btn-new-task" class="btn btn-default" type="button" onclick="Delete(' + full.Id + ')"><span class="glyphicon glyphicon-trash"></span></button>';
                }
            }
        ]
    });
}

function AddTask() {
    const newTaskDescription = $('#input-new-task').val();

    if (newTaskDescription === null || newTaskDescription === '') {
        return false;
    }

    $.ajax({
        url: '/UserTask/Create',
        method: 'POST',
        data: {
            description: newTaskDescription
        },
        dataType: 'json',
        beforeSend: function (data) {
            console.log('beforeSend');
        },
        success: function (data) {
            console.log('success');
            $('#input-new-task').val('');
            BuildData();
        },
        error: function (data) {
            console.log('error');
        }
    });
}

function ChangeState(taskId) {
    $.ajax({
        url: '/UserTask/ChangeState',
        method: 'POST',
        data: {
            id: taskId
        },
        dataType: 'json',
        beforeSend: function (data) {
            console.log('beforeSend');
        },
        success: function (data) {
            console.log('success');
            BuildData();
        },
        error: function (data) {
            console.log('error');
        }
    });
}

function Delete(taskId) {
    $.ajax({
        url: '/UserTask/Delete',
        method: 'POST',
        data: {
            id: taskId
        },
        dataType: 'json',
        beforeSend: function (data) {
            console.log('beforeSend');
        },
        success: function (data) {
            console.log('success');
            BuildData();
        },
        error: function (data) {
            console.log('error');
        }
    });
}
