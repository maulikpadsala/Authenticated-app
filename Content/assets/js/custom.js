$(document).ready(function() {
    // Create two variables with names of months and days of the week in the array
    var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    var dayNames = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"]

    // Create an object newDate()
    var newDate = new Date();
    // Retrieve the current date from the Date object
    newDate.setDate(newDate.getDate());
    // At the output of the day, date, month and year    
    $('#Date').html(dayNames[newDate.getDay()] + " " + newDate.getDate() + ' ' + monthNames[newDate.getMonth()] + ' ' + newDate.getFullYear());

    setInterval(function() {
        // Create an object newDate () and extract the second of the current time
        var seconds = new Date().getSeconds();
        // Add a leading zero to the value of seconds
        $("#sec").html((seconds < 10 ? "0" : "") + seconds);
    }, 1000);

    setInterval(function() {
        // Create an object newDate () and extract the minutes of the current time
        var minutes = new Date().getMinutes();
        // Add a leading zero to the minutes
        $("#min").html((minutes < 10 ? "0" : "") + minutes);
    }, 1000);

    setInterval(function() {
        // Create an object newDate () and extract the clock from the current time
        var hours = new Date().getHours();
        // Add a leading zero to the value of hours
        $("#hours").html((hours < 10 ? "0" : "") + hours);
    }, 1000);


    // -------------------------------------------------datatable

    $("#custom_datatable").DataTable({
        lengthChange: !1,
        pageLength : 5,
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        language: {
            search: "",
            searchPlaceholder: "--- Search Blogs ---",
            paginate: {
                previous: "<i class='arrow_carrot-left'>",
                next: "<i class='arrow_carrot-right'>"
            }
        },
        drawCallback: function() {
            $(".dataTables_paginate > .pagination").addClass("pagination-rounded")
        },
        "bInfo": false,
    });


    $("#mde_jobs_details").DataTable({
        lengthChange: !1,
        pageLength : 5,
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        language: {
            search: "",
            searchPlaceholder: "--- Search Blogs ---",
            paginate: {
                previous: "<i class='arrow_carrot-left'>",
                next: "<i class='arrow_carrot-right'>"
            }
        },
        drawCallback: function() {
            $(".dataTables_paginate > .pagination").addClass("pagination-rounded")
        },
        "bInfo": false,
    });


    // -------------------------------------------------card chages

    

    $(".add_new_btn").click(function(){
        $(".list_card_box").hide();
        $(".add_new_btn").hide();
        $(".form_card_box").show();
        $(".view_list_btn").show();

    });
    $(".view_list_btn").click(function(){
        $(".form_card_box").hide();
        $(".view_list_btn").hide();
        $(".list_card_box").show();
        $(".add_new_btn").show();
    });


    // ------------------------------------------------charts


    

});