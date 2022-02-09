$(document).ready(function() {

    initializecalendar();

});


function initializecalendar() {

    try {

    }
    catch (err) {
        alert(err);
    }

    $('#calendar').fullCalendar({
        timezone: false,
        header: {
            left: 'prev, next, today',
            center: 'title',
            right: 'month, agendaWeek, agendaDay'
        },
        selectable: true,
        editable: false
    });

}