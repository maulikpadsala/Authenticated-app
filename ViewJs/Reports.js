$(document).ready(function () {

    bindPolicydonebyAgent();
    bindAgentCommisson();
});

function bindPolicydonebyAgent()
{
    $.ajax({
        type: "Post",
        url: "../Reports/GetPolicybyAgent",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: "false",
        success: function (data) {
            var table = "";
            if (data.GetAgentPolicyDetail != null) {
                for (var i = 0; i <= (data.GetAgentPolicyDetail.length - 1) ; i++) {
                    var row = "<tr>";
                    row += '<td style="text-align:left;color:black;font-size:12px;">' + data.GetAgentPolicyDetail[i].Agent + '</td>';
                    row += '<td style="text-align:left;color:black;font-size:12px;">' + data.GetAgentPolicyDetail[i].Scheme + '</td>';
                    row += '<td style="text-align:left;color:black;font-size:12px;">' + data.GetAgentPolicyDetail[i].Policy + '</td>';
                    row += '</tr>';
                    table += row;
                }
                $("#tblView").destroy;
                $("#tblView tbody").each(function () { $(this).remove(); });
                $('#tblView').append(table);
                $('#tblView').DataTable({
                    "destroy": true,
                    "order": [],
                    "bFilter": true,
                    "sScrollX": "100%",
                    "sScrollXInner": "100%",
                    "sScrollY": (0.30 * $(window).height()),
                    "bFilter": true,
                    "bInfo": true,
                    "autowidth": false,
                    "paging": true,
                    "pageLength": 5,
                    "lengthMenu": [[5, 10, 15], [5, 10, 15]],
                    "columns": [
                           { "title": "Agent", "orderable": "true" },
                           { "title": "Scheme" },
                           { "title": "Policy" },

                    ],
                    "columnDefs": [
                                 {
                                     'orderable': false, 'targets': [0, 1, 2], "createdCell": function (td, cellData, rowData, row, col) {
                                         $(td).css('padding', '5px')
                                     }
                                 }
                    ]
                });
                $("#tblView th").each(function () {
                    var txt = $(this).text();
                    if (txt == "") {
                        $(this).removeClass("sorting");
                    }
                });
            }
        },
        error: function (response) {
            //alert('error');
        }
    });
}

function bindAgentCommisson() {
    $.ajax({
        type: "Post",
        url: "../Reports/GetAgentCommission",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: "false",
        success: function (data) {
            var table = "";
            if (data.Getagentcommission != null) {
                for (var i = 0; i <= (data.Getagentcommission.length - 1) ; i++) {
                    var row = "<tr>";
                    row += '<td style="text-align:left;color:black;font-size:12px;">' + data.Getagentcommission[i].Agent + '</td>';
                    row += '<td style="text-align:left;color:black;font-size:12px;">' + data.Getagentcommission[i].Commission + "%" + '</td>';
                    row += '</tr>';
                    table += row;
                }
                $("#tblViews").destroy;
                $("#tblViews tbody").each(function () { $(this).remove(); });
                $('#tblViews').append(table);
                $('#tblViews').DataTable({
                    "destroy": true,
                    "order": [],
                    "bFilter": true,
                    "sScrollX": "100%",
                    "sScrollXInner": "100%",
                    "sScrollY": (0.30 * $(window).height()),
                    "bFilter": true,
                    "bInfo": true,
                    "autowidth": false,
                    "paging": true,
                    "pageLength": 5,
                    "lengthMenu": [[5, 10, 15], [5, 10, 15]],
                    "columns": [
                           { "title": "Agent", "orderable": "true" },
                           { "title": "Commission (%)" },
                          
                    ],
                    "columnDefs": [
                                 {
                                     'orderable': false, 'targets': [0, 1], "createdCell": function (td, cellData, rowData, row, col) {
                                         $(td).css('padding', '5px')
                                     }
                                 }
                    ]
                });
                $("#tblViews th").each(function () {
                    var txt = $(this).text();
                    if (txt == "") {
                        $(this).removeClass("sorting");
                    }
                });
            }
        },
        error: function (response) {
            //alert('error');
        }
    });
}