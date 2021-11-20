$(document).ready(function ()
{
    ComboAgentGroup();
    ComboScheme();
    $("#ddlSchemeName").change(function () {
        if ($('option:selected', $(this)).text() == "Long term") {
            var num = 2;
            var comm = (num * 12.5) / 100;
            num += comm;
            $("#txtCommission").val(num);
        }
        if ($('option:selected', $(this)).text() == "Short term") {
            var num = 3;
            var comm = (num * 12.5) / 100;
            num += comm;
            $("#txtCommission").val(num);
        }

    });

    $("#btnSave").click(function (e) {
        e.preventDefault();
        if ($("#hfMastCode").val() == "") {
            $("#hfMastCode").val(0);
        }

        if ($("#txtCustomerName").val().trim() == "") {
            $("div#errMsg").css("color", "red");
            $("div#errMsg").html("Please enter customer name");
            return false;
        }

        var alphanumers = /^[a-zA-Z0-9-_\d\s]+$/i;
        if (!alphanumers.test($("#txtCustomerName").val())) {
            $("div#errMsg").css("color", "red");
            $("div#errMsg").html("Customer Name can have only alphabets and numbers.");
            $("#txtCustomerName").val('');
            return false;
        }

        if ($("#ddlAgentName").val() == 0) {
            $("div#errMsg").css("color", "red");
            $("div#errMsg").html("Please select agent name");
            return false;
        }

        if ($("#txtPolicyNo").val().trim() == "") {
            $("div#errMsg").css("color", "red");
            $("div#errMsg").html("Please enter policy number");
            return false;
        }

        var alphanumers = /^[0-9-_\d]+$/i;
        if (!alphanumers.test($("#txtPolicyNo").val())) {
            $("div#errMsg").css("color", "red");
            $("div#errMsg").html("Policy number can have only numbers.");
            $("#txtPolicyNo").val('');
            return false;
        }

        if ($("#ddlSchemeName").val() == 0) {
            $("div#errMsg").css("color", "red");
            $("div#errMsg").html("Please select scheme name");
            return false;
        }

        if ($("#txtPolicyAmt").val().trim() == "") {
            $("div#errMsg").css("color", "red");
            $("div#errMsg").html("Please Enter policy amount");
            return false;
        }
        if ($("#txtPolicyAmt").val().trim() <= 0) {
            $("div#errMsg").css("color", "red");
            $("div#errMsg").html("Please Enter Valid policy amount");
            return false;
        }


        var ObjPolicyDetails = {
            PolicyNo: $("#txtPolicyNo").val().trim(),
            Date: $("#startDate").val(),
            SchemeNo: $("#ddlSchemeName").val(),
            AgentNo: $("#ddlAgentName").val(),
            CustomerName: $("#txtCustomerName").val().trim(),
            Commission: $("#txtCommission").val(),
            PolicyAmount: $("#txtPolicyAmt").val().trim()

        };
        $.ajax({
            type: "POST",
            url: "../Home/AddPolicyData",
            data: JSON.stringify({ 'ObjPolicyDetails': ObjPolicyDetails }),
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            async: "true",
            success: function (data) {
                if (data.ErrorCode == 1) {
                    $("div#errMsg").css("color", "Green");
                    $("div#errMsg").html(data.ErrorDescription);
                    $("#txtPolicyNo").val('');
                    $("#txtDate").val('');
                    $("#ddlSchemeName").val(0);
                    $("#ddlAgentName").val(0);
                    $("#txtCustomerName").val('');
                    $("#txtCommission").val('');
                    $("#txtPolicyAmt").val('')
                }
                else {
                    $("div#errMsg").css("color", "red");
                    $("div#errMsg").html(data.ErrorDescription);
                }
            },
            error: function (data) {
                //alert('error');
            }
        });
    });

    $("#btnCancel").click(function (e) {
        $("#txtPolicyNo").val('');
        $("#txtDate").val('');
        $("#ddlSchemeName").val(0);
        $("#ddlAgentName").val(0);
        $("#txtCustomerName").val('');
        $("#txtCommission").val('');
        $("#txtPolicyAmt").val('');
    });

});
        
function ComboAgentGroup() {
    $.ajax({
        type: "Post",
        url: "../Home/ComboAgentData",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        acync: false,
        success: function (data) {
          
            if (data.GetAgentDetails != null) {
                for (var i = 0; i <= (data.GetAgentDetails.length - 1) ; i++) {
                    $("#ddlAgentName").append("<option value='" + data.GetAgentDetails[i].AgentNo + "'>" + data.GetAgentDetails[i].AgentName + "</option>");
                }
            }
        },
        error: function (response) {
            //alert(response);
        }
    });
}

function ComboScheme() {
    $.ajax({
        type: "Post",
        url: "../Home/ComboSchemeData",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        acync: false,
        success: function (data) {
            if (data.GetSchemeDetails != null) {
                for (var i = 0; i <= (data.GetSchemeDetails.length - 1) ; i++) {
                    $("#ddlSchemeName").append("<option value='" + data.GetSchemeDetails[i].SchemeNo + "'>" + data.GetSchemeDetails[i].SchemeName + "</option>");
                }
            }
        },
        error: function (response) {
            //alert(response);
        }
    });
}