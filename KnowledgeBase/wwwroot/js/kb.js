(function ($) {
    var $ssb = {};
    $ssb.toFormData = function (obj) {
        if (typeof obj == undefined)
            return undefined;

        var data = new FormData();

        for (var i in obj) {
            if (Array.isArray(obj[i])) {
                var arr = obj[i]
                for (var k in arr) {
                    data.append(i, arr[k]);
                }
            } else
                data.append(i, obj[i]);
        }
        return data;
    }
    $ssb.post = function (url, data, callback) {
        if ($.isFunction(data)) {
            callback = data;
            data = undefined;
        }
        var ret = Ajax('post', url, data, callback);
        return ret;
    }
    $ssb.get = function (url, data, callback) {
        if ($.isFunction(data)) {
            callback = data;
            data = undefined;
        }
        var ret = Ajax('get', url, data, callback);
        return ret;
    }
    //用来返回html
    $ssb.asyncRender = function (url, data, callback) {
        if ($.isFunction(data)) {
            callback = data;
            data = undefined;
        }
        $.ajax({
            url: url,
            type: 'post',
            data: data,
            datatype: 'html',
            success: function (content) {
                callback(content);
            },
            error: errorCallback
        })
    }
    $ssb.alert = function (msg, callback) {
        layerAlert(msg, callback);
    }
    $ssb.confirm = function (msg, callback) {
        layerConfirm(msg, callback);
    }
    $ssb.msg = function (msg, callback) {
        layerMsg(msg, callback);
    }
    $ssb.renderHtml = function (title, content, w, h) {
        layerOpen(title, content, w, h, 1);
    }
    $ssb.renderIframe = function (title, content, w, h) {
        layerOpen(title, content, w, h, 2);
    }
    //关闭Iframe弹出层
    $ssb.close = function () {
        var index = parent.layer.getFrameIndex(window.name);//获得窗口的索引
        parent.layer.close(index);
    }
    $ssb.validForm = function (el, tiptype, label) {
        var validForm = el.Validform({
            tiptype: tiptype, label: label
        })
        return validForm.check(false);
    }
    function Ajax(type, url, data, callback) {
        var layerIndex = layer.load(1);
        var retAjax = $.ajax({
            url: url,
            type: type,
            data: data,
            datatype: 'json',
            complete: function () {
                layer.close(layerIndex);
            },
            success: function (result) {
                var isStandardResult = ("status" in result) && ("errorMsg" in result);
                if (isStandardResult) {
                    if (result.status == 'error') {
                        layerAlert(result.errorMsg || "操作失败");
                        return;
                    }
                    if (result.status == 'redirect') {
                        layerAlert(result.errorMsg || "未登录或登录过期，请重新登录", function () {
                            location.href = result.data + '?returnurl=' + window.location.href;  //重定向url存在data中。
                        });

                    }
                    //if (result.status == ResultStatus.Unauthorized) {
                    //    layerAlert(result.errorMsg || "权限不足，禁止访问");
                    //    return;
                    //}

                    if (result.status == "ok") {
                        /* 传 result，用 result.Data 还是 result.Msg，由调用者决定 */
                        callback(result);
                    }
                    else {
                        callback(result);
                    }
                }
                else
                    callback(result);

            },
            error: errorCallback

        })
        return retAjax;
    }
    function errorCallback(xhr) {
        //var json = { textStatus: textStatus, errorThrown: errorThrown };JSON.stringify(json)
        alert("请求出错");
    }
    function layerAlert(msg, callBack) {
        msg = msg == null ? "" : msg; /* layer.alert 传 null 会报错 */
        var type = 'warning';
        var icon = "";
        if (type == 'success') {
            icon = "fa-check-circle";
        }
        if (type == 'error') {
            icon = "fa-times-circle";
        }
        if (type == 'warning') {
            icon = "fa-exclamation-circle";
        }

        var idx;
        idx = layer.alert(msg, {
            icon: icon,
            title: "系统提示",
            btn: ['确认'],
            btnclass: ['btn btn-primary'],
        }, function () {
            layer.close(idx);
            if (callBack)
                callBack();
        });
    }
    function layerConfirm(content, callBack) {
        var idx;
        idx = layer.confirm(content, {
            icon: "fa-exclamation-circle",
            title: "系统提示",
            btn: ['确认', '取消'],
            btnclass: ['btn btn-primary', 'btn btn-danger'],
        }, function () {
            layer.close(idx);
            callBack();
        }, function () {

        });
    }
    function layerMsg(msg, callBack) {
        msg = msg == null ? "" : msg;/* layer.msg 传 null 会报错 */
        layer.msg(msg, { time: 1000, shift: 0 }, function () {
            if (callBack)
                callBack();
        });
    }
    function layerOpen(title, content, w, h, type) {
        layer.open({
            type: type,
            title: title,
            shadeClose: true,
            shade: 0.8,
            area: [w + 'px', h + 'px'],
            content: content
        });
    }
    window.$kb = $ssb;

})($);