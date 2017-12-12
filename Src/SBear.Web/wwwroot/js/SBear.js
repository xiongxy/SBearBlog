SBear = {};
SBear.Modal = {};
SBear.Modal.Enable = function (settings) {
    settings = SBear.Modal.Init(settings);
    SBear.Modal.AddContent(settings);
    SBear.Modal.AddEvent(settings);
    if (typeof parseInt(settings.timeout) === "number" && !isNaN(parseInt(settings.timeout))) {
        setTimeout("SBear.Modal.Close();", settings.timeout);
    }
    $("#" + settings.id + "").modal({
        backdrop: settings.backdrop
    });
    $("#" + settings.id + "").on('hidden.bs.modal',
        function () {
            SBear.Modal.Close();
        });
}
SBear.Modal.Init = function (settings) {
    var defaultSettings = {
        id: "myModal",
        title: "提示",
        content: "",
        btns: [{ id: "btn_save", text: "保存", function: function () { } }, { id: "closebtn" }],//按钮组
        timeout: "",
        backdrop: "static",
        size: "sm",//lg sm
        showclosebtn: true//显示关闭按钮
    }
    SBear.Modal.Settings = $.extend({}, defaultSettings, settings || {});
    return SBear.Modal.Settings;
}
SBear.Modal.AddContent = function (settings) {
    var modalSize = "";
    var modaldialogSize = "";
    if (settings.size === "lg") { modalSize = "bs-example-modal-lg"; modaldialogSize = "modal-lg"; }
    else if (settings.size === "sm") { modalSize = "bs-example-modal-sm"; modaldialogSize = "modal-sm"; }
    var modal = $('<div class="modal fade ' + modalSize + '" id="' + settings.id + '" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"></div>');
    var modaldialog = $('<div class="modal-dialog ' + modaldialogSize + '" style="top:45%;transform:translateY(-50%);" role="document"></div>');
    var modalcontent = $('<div class="modal-content"></div>');
    var modalheader = $('<div class="modal-header"></div>');
    var modalbody = $('<div class="modal-body"></div>');
    var modalfooter = $('<div class="modal-footer"></div>');
    if (settings.showclosebtn) {
        $(modalheader).append('<button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>');
    }
    $(modalheader).append(settings.title);
    $(modalbody).append(settings.content);
    settings.btns.forEach(function (btn) {
        var btnclass = btn.class || "btn-primary";
        var btntemp;
        if (btn.id !== "closebtn") {
            btntemp = $('<button class="btn" type="button" id="' + btn.id + '">' + btn.text + '</button>');
            $(btntemp).addClass(btnclass);
        } else {
            btntemp = $('<button class="btn btn-default" type="button" data-dismiss="modal" aria-hidden="true" id="' + btn.id + '">关闭</button>');
        }
        $(modalfooter).append(btntemp);
    });
    modalcontent.append(modalheader).append(modalbody).append(modalfooter);
    modaldialog.append(modalcontent);
    modal.append(modaldialog);
    $("body").append(modal);
}
SBear.Modal.AddEvent = function (settings) {
    settings.btns.forEach(function (btn) {
        $("#" + btn.id + "").on("click", btn.function);
    });
}
SBear.Modal.Close = function () {
    $("#" + SBear.Modal.Settings.id + "").remove();
}