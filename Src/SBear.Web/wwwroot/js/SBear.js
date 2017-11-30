
SBear.Modal.dialog({
    title: "操作提示",
    content: "<h3>确认要将今日12.12所有未取票订单做出票处理？（PS：此操作无法恢复）</h3>",
    ok: function () {
        SBear.Modal.dialog.close();
        window.external.NoTakingHandle(3);
    }
});
function ModalCall(result) {
    SBear.Modal.dialog({
        title: "",
        content: result,
        type: "qita",
        timeout: "2000",
        ok: function () {
            SBear.Modal.dialog.close();
        }
    });
};
SBear = {};
//基于Bootstrap制作的modal
SBear.Modal = {};
SBear.Modal.Init = function (settings) {
    var defaultSettings = {
        title: "提示",
        content: ""
    }
    SBear.Modal.Settings = $.extend({}, defaultSettings, settings || {});
    return SBear.Modal.Settings;
}
SBear.Modal.Settings = {

}
SBear.Modal.dialog = function (settings) {
    settings = SBear.Modal.Init(settings);
    SBear.Modal.initContent();
    debugger;
    //关闭的时候调用方法
    if (SBear.Modal.settings.ok) {
        $("#modal-overlay #modal-overlay-ok").click(settings.ok);
    }
    if (SBear.Modal.settings.cancel) {
        $("#modal-overlay #modal-overlay-cancel").click(settings.cancel);
    }
    if (typeof parseInt(SBear.Modal.settings.timeout) === "number" && !isNaN(parseInt(SBear.Modal.settings.timeout))) {
        setTimeout("SBear.Modal.dialog.close();", SBear.Modal.settings.timeout);
    }
}
SBear.Modal.initContent = function () {
    var modalHtml =
        "<div id=\"modal-overlay\" class=\"modal fade bs-example-modal-sm\" tabindex=\"-1\" role=\"dialog\">" +
        "<div class=\"modal-dialog modal-sm\" role=\"document\">" +
        "<div class=\"modal-content\">" +
        "<div class=\"modal-header\"></div>" +
        "<div class=\"modal-body\"></div>" +
        "<div class=\"modal-footer\"></div>" +
        "</div>" +
        "</div>" +
        "</div>";
    var $modalHtml = $(modalHtml);
    $(".modal-header", $modalHtml).text(SBear.Modal.Settings.okVal);
    $(".modal-body", $modalHtml).text(SBear.Modal.Settings.okVal);
    $(".modal-footer", $modalHtml).text(SBear.Modal.Settings.okVal);
    $("body").append($modalHtml);
}
SBear.Modal.dialog.close = function () {
    var e1 = document.getElementById("modal-overlay");
    document.body.removeChild(e1);
}
