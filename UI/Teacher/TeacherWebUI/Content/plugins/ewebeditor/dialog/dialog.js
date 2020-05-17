/*
*######################################
* eWebEditor V9.0 - Advanced online web based WYSIWYG HTML editor.
* Copyright (c) 2003-2013 eWebSoft.com
*
* For further information go to http://www.ewebeditor.net/
* This copyright notice MUST stay intact for use.
*######################################
*/

var cc = new Object();
var xm = document.location.search.substr(1).split('&');
for (i = 0; i < xm.length; i++) {
    var xF = xm[i].split('=');
    cc[xF[0]] = xF[1];
}
var EWIN = parent.EWIN;
var EWEB = EWIN.EWEB;
var ec = EWIN.ec;
var R = EWIN.R;
var F = EWIN.F;
var aA = EWIN.aA;
var lang = EWIN.lang;
var config = EWIN.config;
var C = EWIN.C;
var dP = parent.dP();
if (dP) {
    dP = dP.contentWindow.yu;
}
R.lE(window);
function lC(ay, bv) {
    return (cc[ay]) ? cc[ay] : bv;
};
function ng(url) {
    document.write('<scr' + 'ipt type="text/javascript" src="' + url + '"><\/scr' + 'ipt>');
};
function fk(bM) {
    qS = 0;
    qw = bM.length;
    if (fk.arguments.length == 2) {
        pF = fk.arguments[1].toLowerCase();
    } else {
        pF = "all";
    }
    for (var i = 0; i < bM.length; i++) {
        xY = bM.substring(qS, qS + 1);
        xH = bM.substring(qw, qw - 1);
        if ((pF == "all" || pF == "left") && xY == " ") {
            qS++;
        }
        if ((pF == "all" || pF == "right") && xH == " ") {
            qw--;
        }
    }
    bM = bM.slice(qS, qw);
    return bM;
};
function bX(wz, zj) {
    alert(zj);
    wz.focus();
    wz.select();
    return false;
};
function oV(color) {
    var temp = color;
    if (temp == "") return true;
    if (temp.length != 7) return false;
    return (temp.search(/\#[a-fA-F0-9]{6}/) != -1);
};
function AN(bM) {
    return (bM.search(/[^0-9]+/) == -1);
};
function Ck(bM) {
    return (AN(bM) && parseInt(bM) > 0);
};
function eR(e) {
    if (!e) {
        e = window.event;
    }
    if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 96 && e.keyCode <= 105) || (e.keyCode >= 35 && e.keyCode <= 40) || e.keyCode == 46 || e.keyCode == 8) {
        return true;
    }
    return R.aw(e);
};
function hu(tj) {
    var aG = "selcolor.htm?returnfieldflag=" + tj;
    ec.OpenDialog(aG);
};
function vo() {
    ec.OpenDialog("backimage.htm?action=other");
};
function nf(type, tj) {
    ec.OpenDialog('browse.htm?returnfieldflag=' + tj + '&type=' + type);
};
function aC(xd, bv) {
    for (var i = 0; i < xd.length; i++) {
        if (xd.options[i].value == bv) {
            xd.selectedIndex = i;
            return true;
        }
    }
    return false;
};
function fe(bM) {
    bM = fk(bM);
    if (bM != "") {
        var ho = parseFloat(bM);
        if (isNaN(ho)) {
            bM = "";
        } else {
            bM = ho;
        }
    }
    return bM;
};
function zC(url) {
    var ho;
    var b = true;
    ho = url.substring(0, 7);
    ho = ho.toUpperCase();
    if ((ho != "HTTP://") || (url.length < 10)) {
        b = false;
    }
    return b;
};
function iV(url, mb) {
    var ho;
    var b = false;
    var s = mb.toUpperCase().split("|");
    for (var i = 0; i < s.length; i++) {
        ho = url.substr(url.length - s[i].length - 1);
        ho = ho.toUpperCase();
        s[i] = "." + s[i];
        if (s[i] == ho) {
            b = true;
            break;
        }
    }
    return b;
};
function tX(aG) {
    if (aG.substring(0, 1) == "/") {
        return aG;
    }
    if (aG.indexOf("://") >= 0) {
        return aG;
    }
    var qc = EWEB.cd;
    while (aG.substr(0, 3) == "../") {
        aG = aG.substr(3);
        qc = qc.substring(0, qc.lastIndexOf("/"));
    }
    return qc + "/" + aG;
};
function qf(aG) {
    if (config.BaseHref == "") {
        return aG;
    }
    if (aG.substring(0, 1) == "/") {
        return aG;
    }
    if (aG.indexOf("://") >= 0) {
        return aG;
    }
    var hN = config.BaseHref;
    hN = hN.substring(0, hN.length - 1);
    while (aG.substring(0, 3) == "../") {
        aG = aG.substr(3);
        hN = hN.substring(0, hN.lastIndexOf("/"));
    }
    return hN + "/" + aG
};
function AI(aG) {
    var oT = EWEB.cd + "/plugin/";
    while (true) {
        var n1 = aG.indexOf("/");
        var n2 = oT.indexOf("/");
        if (n1 >= 0 && n1 == n2) {
            if (aG.substring(0, n1 + 1) == oT.substring(0, n2 + 1)) {
                aG = aG.substr(n1 + 1);
                oT = oT.substr(n2 + 1);
            } else {
                break;
            }
        } else {
            break;
        }
    }
    var s = oT.replace(/[^\/]+/gi, '');
    var n = s.length;
    for (var i = 0; i < n; i++) {
        aG = "../" + aG;
    }
    return aG;
};
function gh(url) {
    switch (config.BaseUrl) {
        case "0":
            url = tX(url);
            return Af(url);
            break;
        case "1":
            return tX(url);
            break;
        case "2":
        case "3":
            return EWEB.hW + tX(url);
            break;
    }
};
function Af(url) {
    var baseHref = config.BaseHref;
    var b = true;
    while (b) {
        var n1 = url.indexOf("/");
        var n2 = baseHref.indexOf("/");
        if ((n1 >= 0) && (n2 >= 0)) {
            var u1 = url.substring(0, n1 + 1);
            var u2 = baseHref.substring(0, n2 + 1);
            if (u1 == u2) {
                url = url.substr(n1 + 1);
                baseHref = baseHref.substr(n2 + 1);
            } else {
                b = false;
            }
        } else {
            b = false;
        }
    }
    if (baseHref != "") {
        var a = baseHref.split("/");
        for (var i = 1; i < a.length; i++) {
            url = "../" + url;
        }
    }
    return url;
};
function Bn() {
    var w = tabDialogSize.offsetWidth + 6;
    var h = tabDialogSize.offsetHeight + 25;
    if (F.BW) {
        h += 20;
    }
    window.dialogWidth = w + "px";
    window.dialogHeight = h + "px";
    window.dialogLeft = (screen.availWidth - w) / 2;
    window.dialogTop = (screen.availHeight - h) / 2;
};
function Ao(el) {
    if (!el["imageinitliazed"]) {
        el["oncontextmenu"] = new Function("event.returnValue=false");
        el["onmouseout"] = new Function("wn(this)");
        el["onmousedown"] = new Function("wA(this)");
        el["unselectable"] = "on";
        el["imageinitliazed"] = true;
    }
    el.className = "Ao";
};
function wn(el) {
    el.className = "wn";
};
function wA(el) {
    el.className = "wA";
};
function lN(cT) {
    var qd;
    switch (cT) {
        case "image":
            qd = config.AllowImageSize;
            break;
        case "flash":
            qd = config.AllowFlashSize;
            break;
        case "media":
            qd = config.AllowMediaSize;
            break;
        case "file":
            qd = config.AllowFileSize;
            break;
        default:
            return "";
    }
    var Ad = parseFloat(qd) * 1024;
    var html = "<iframe name='myuploadformtarget' style='display:none;position:absolute;width:0px;height:0px' src='blank.htm'></iframe>" + "<form action='../" + config.ServerExt + "/upload." + config.ServerExt + "?action=save&type=" + cT + "&style=" + aA.StyleName + "&cusdir=" + aA.CusDir + "&skey=" + aA.SKey + "' method=post name=myuploadform enctype='multipart/form-data' style='margin:0px;padding:0px;width:100%;border:0px;' target='myuploadformtarget'>" + "<input type=hidden name='MAX_FILE_SIZE' value='" + Ad + "'>" + "<input type=file name='uploadfile' id='uploadfile' size=28  onchange=\"this.form.originalfile.value=this.value;try{eT();} catch(e){}\">" + "<input type=hidden name='originalfile' value=''>" + "</form>";
    return html;
};
function md(an, cs, Ay) {
    var ii = "";
    switch (an) {
        case "ext":
            ii = lang["ErrUploadInvalidExt"] + ":" + cs;
            break;
        case "size":
            ii = lang["ErrUploadSizeLimit"] + ":" + Ay + "KB";
            break;
        case "file":
            ii = lang["ErrUploadInvalidFile"];
            break;
        case "style":
            ii = lang["ErrInvalidStyle"];
            break;
        case "space":
            ii = lang["ErrUploadSpaceLimit"] + ":" + config.SpaceSize + "MB";
            break;
        default:
            ii = an;
            break;
    }
    return ii;
};
function pR(ay) {
    var yW = "";
    var gr = ay + "=";
    if (document.cookie.length > 0) {
        ro = document.cookie.indexOf(gr);
        if (ro != -1) {
            ro += gr.length;
            var eQ = document.cookie.indexOf(";", ro);
            if (eQ == -1) {
                eQ = document.cookie.length;
            }
            yW = unescape(document.cookie.substring(ro, eQ));
        }
    }
    return yW;
};
function qz(ay, bv) {
    var pS = "";
    pS = new Date((new Date()).getTime() + 24 * 365 * 3600000);
    pS = ";expires=" + pS.toGMTString();
    document.cookie = ay + "=" + escape(bv) + pS;
};
var aZ;
function eY(ri) {
    if (aZ) {
        aZ = null;
    }
    var b = false;
    try {
        aZ = new ActiveXObject("eWebSoft.eWebEditor5");
        var oC = aZ.Version;
        if (parseFloat(oC.replace(/[^0123456789]+/gi, "")) >= 5100) {
            aZ.Lang = "zh-cn";
            aZ.Charset = config.Charset;
            aZ.SendUrl = EWEB.SendUrl;
            aZ.LocalSize = config.AllowLocalSize;
            aZ.LocalExt = config.AllowLocalExt;
            b = true;
        }
    } catch (e) { }
    if (!b && ri) {
        if (F.Cq) {
            alert(lang["MsgOnlyFor32Bit"]);
        } else {
            ec.OpenDialog("installactivex.htm");
        }
    }
    return b;
};
function CheckPrinterInstall(ri) {
    if (!aZ) {
        aZ = new ActiveXObject("eWebSoft.eWebEditor5");
    }
    var b = aZ.IsPrinterExist();
    if (!b && ri) {
        ec.OpenDialog("installprinter.htm");
    }
    return b;
};
function es() {
    var dU = aZ.Error;
    if (dU != "") {
        var fX, ge;
        if (dU.indexOf(":") >= 0) {
            var a = dU.split(":");
            fX = a[0];
            ge = a[1];
        } else {
            fX = dU;
            ge = "";
        }

        switch (fX) {
            case "L":
                alert(lang["ErrLicense"]);
                break;
            case "InvalidFile":
                alert(lang["ErrInvalidFile"] + ":" + ge);
                break;
            default:
                alert(dU);
        }
        return true;
    }
    return false;
};
function bq(kG, dg, iG) {
    if (iG == null || iG.length == 0) {
        kG.removeAttribute(dg, 0);
    } else {
        kG.setAttribute(dg, iG, 0);
    }
};
function nP(kG, bL, fO) {
    bq(kG, "_ewebeditor_ta_" + bL, encodeURIComponent(fO));
};
function dE(kG, dg) {
    var fu = kG.attributes[dg];
    if (fu == null || !fu.specified) {
        return "";
    }
    var bv = kG.getAttribute(dg, 2);
    if (bv == null) {
        bv = fu.nodeValue;
    }
    return (bv == null ? "" : bv);
};
function eZ(el, dg) {
    dg = dg.replace(/\-(\w)/g,
    function (Cz, p1) {
        return p1.toUpperCase();
    });
    var bv = el.style[dg];
    if (bv && (!F.as) && dg.indexOf("Color") >= 0) {
        bv = zr(bv);
    }
    if (!bv) {
        switch (dg) {
            case "backgroundColor":
                dg = "bgColor";
                break;
            case "textAlign":
                dg = "align";
                break;
            case "verticalAlign":
                dg = "valign";
                break;
            default:
        }
        bv = dE(el, dg);
    }
    return bv;
};
function lZ(bv) {
    var n = parseInt(bv);
    if (isNaN(n)) {
        return '';
    }
    if (bv.substr(bv.length - 1) != "%") {
        bv = n + "";
    }
    return bv;
};
function vH(el, bL) {
    var yV = "_ewebeditor_ta_" + bL;
    var wU = el.attributes[yV];
    if (wU == null || !wU.specified) {
        return dE(el, bL);
    } else {
        return decodeURIComponent(el.getAttribute(yV, 2));
    }
};
function xV(el) {
    return dE(el, "_ewebeditor_fake_tag");
};
function wi(el) {
    return decodeURIComponent(dE(el, "_ewebeditor_fake_value"));
};
function zG(el, V) {
    bq(el, '_ewebeditor_fake_value', encodeURIComponent(V));
};
function ty(N) {
    if (N == null) return "00";
    N = parseInt(N);
    if (N == 0 || isNaN(N)) return "00";
    N = Math.max(0, N);
    N = Math.min(N, 255);
    N = Math.round(N);
    return "0123456789ABCDEF".charAt((N - N % 16) / 16) + "0123456789ABCDEF".charAt(N % 16);
};
function zr(bM) {
    if (bM.substring(0, 3) == 'rgb') {
        var by = bM.split(",");
        var r = by[0].replace('rgb(', '').trim();
        var g = by[1].trim();
        var b = by[2].replace(')', '').trim();
        var hex = [ty(r), ty(g), ty(b)];
        return "#" + hex.join('');
    } else {
        return bM;
    }
};
var aj = {
    Init: function (V) {
        this.pL = new Object();
        this.Html = V;
        var re = new RegExp("<object(?=[\\s>])", "gi");
        if (re.test(V)) {
            this.oA = "object";
            re = /<param\s+name\s*?=\s*?([\'\"]?)(\w+)\1[\s]+value\s*?=\s*?(\w+|\'[^\'>]+\'|\"[^\">]+\")[^>]*?>/gi;
            while ((by = re.exec(V)) != null) {
                var fz = RegExp.$3;
                if (fz.substring(0, 1) == '\'' || fz.substring(0, 1) == '"') {
                    fz = fz.substring(1, fz.length - 1);
                }
                this.pL[RegExp.$2.toLowerCase()] = fz;
            }
        } else {
            this.oA = "common";
            re = /\s(\w+)\s*?=\s*?(\w+|\'[^\'>]+\'|\"[^\">]+\")/gi;
            while ((by = re.exec(V)) != null) {
                var fz = RegExp.$2;
                if (fz.substring(0, 1) == '\'' || fz.substring(0, 1) == '"') {
                    fz = fz.substring(1, fz.length - 1);
                }
                this.pL[RegExp.$1.toLowerCase()] = fz;
            }
        }
    },
    GetValue: function (bA) {
        return (this.pL[bA]) ? this.pL[bA] : "";
    },
    GetHtml: function () {
        return this.Html;
    },
    jk: function (bA, bv) {
        var V = this.Html;
        function gm(m, m1) {
            if (bv == '') {
                return '';
            } else {
                return '<param name="' + bA + '" value="' + bv + '">';
            }
        };
        function gC(m) {
            return m + '<param name="' + bA + '" value="' + bv + '">';
        };
        if (this.oA == 'object') {
            var re = new RegExp('<param(?=\\s)[^>]*?\\sname\\s*?=\\s*?(\w+|\'[^\'>]+\'|\"[^\">]+\")[^>]*?>', 'gi');
            if (re.test(V)) {
                V = V.replace(re, gm);
            } else {
                if (bv != '') {
                    V = V.replace(/<object[^>]*?>/, gC);
                }
            }
            V = this.wD(V, 'embed', bA, bv);
        } else {
            V = this.wD(V, '\\w+', bA, bv);
        }
        this.Html = V;
    },
    wD: function (V, aH, bA, bv) {
        function gm(m, m1, m2, m3) {
            if (bv == '') {
                return m1 + m3;
            } else {
                return m1 + ' ' + bA + '="' + bv + '"' + m3;
            }
        };
        function gC(m) {
            return m.substring(0, m.length - 1) + ' ' + bA + '="' + bv + '">';
        };
        var re = new RegExp('(<' + aH + '(?=[\\s>])[^>]*?)\\s' + bA + '\\s*?=\\s*?(\w+|\'[^\'>]+\'|\"[^\">]+\")([^>]*>)', 'gi');
        if (re.test(V)) {
            V = V.replace(re, gm);
        } else {
            if (bv != '') {
                re = new RegExp('<' + aH + '(?=[\\s>])[^>]*>', 'gi');
                V = V.replace(re, gC);
            }
        }
        return V;
    }
};
var ck = {
    Click: function (dO, iq) {
        if ($("tab_nav_" + dO).className == "tab_on") {
            return;
        }
        var pV, bZ, pE;
        for (var i = 1; i <= iq; i++) {
            pV = "tab_nav_" + i;
            bZ = $(pV).getAttribute("_content_id", 2);
            if ($(pV).className == "tab_on") {
                if (!ck.iy) {
                    ck.iy = new Array();
                }
                if (!ck.iy[i]) {
                    ck.iy[i] = {
                        Width: $("tabDialogSize").offsetWidth,
                        Height: $("tabDialogSize").offsetHeight
                    };
                }
                if (!ck.jp) {
                    ck.jp = new Array();
                }
                if (!ck.jp[i]) {
                    ck.jp[i] = {
                        Width: $(bZ).offsetWidth,
                        Height: $(bZ).offsetHeight
                    };
                }
                $(pV).className = "tab_off";
                $(bZ).style.display = "none";
            }
            if (dO == i) {
                pE = bZ;
            }
        }
        $("tab_nav_" + dO).className = "tab_on";
        $(pE).style.display = "";
        try {
            jS(dO, iq, pE);
        } catch (e) { }
    },
    lQ: function (qF) {
        var V = '<table class=tab_layout1 border=0 cellpadding=0 cellspacing=0 width="100%"><tr><td>' + '<table class=tab_layout2 border=0 cellpadding=0 cellspacing=0><tr>' + '<td class=tab_begin></td>';
        for (var i = 1; i <= qF.length; i++) {
            var rg = 'tab_on';
            if (i > 1) {
                V += '<td class=tab_sep></td>';
                rg = 'tab_off';
            }
            V += '<td><table id="tab_nav_' + i + '" class="' + rg + '" _content_id="' + qF[i - 1][1] + '" border=0 cellpadding=0 cellspacing=0><tr>' + '<td class=tab_left></td>' + '<td class=tab_center onclick="ck.Click(' + i + ',' + qF.length + ')">' + qF[i - 1][0] + '</td>' + '<td class=tab_right></td>' + '</tr></table></td>';
        }
        V += '</tr></table></td></tr></table>';
        document.write(V);
    }
};
var iU = {
    Load: function (cT, zI, eh, ff, rh) {
        if (this.AB) {
            return;
        }
        this.yz = cT;
        this.nU = zI;
        this.yQ = rh || '1';
        this.nU.style.width = eh;
        this.nU.style.height = ff;
        if (F.as) {
            if (!eY(true)) {
                this.rS(lang["DlgComNotice"] + "<br>" + lang["DlgComMFUMsgNotInstall"]);
                this.xO();
                return;
            }
            this.we();
        } else {
            this.rS(lang["DlgComNotice"] + "<br>" + lang["MsgOnlyForIE"]);
            return;
        }
    },
    xO: function () {
        if (!eY(false)) {
            window.setTimeout("iU.xO()", 1000);
        } else {
            var V = "<span class=red><b>" + lang["DlgComMFUMsgInstallOk"] + "</b></span><br><br><input type=button class='dlgBtn' value='" + lang["DlgComMFUMsgBtnOk"] + "' onclick='iU.we()'>";
            this.rS(V);
        }
    },
    rS: function (V) {
        this.nU.innerHTML = '<table border=0 cellpadding=0 cellspacing=5 width="100%" height="100%"><tr><td align=center valign=middle>' + '<table border=0 cellpadding=0 cellspacing=5>' + '<tr valign=top>' + '<td><img border=0 src="images/info.gif" align=absmiddle></td>' + '<td>' + V + '</td>' + '</tr>' + '</table>' + '</td></tr></table>';
    },
    we: function () {
        var lH, lL;
        switch (this.yz) {
            case 'image':
                lH = config.AllowImageSize;
                lL = config.AllowImageExt;
                break;
            case 'media':
                lH = config.AllowMediaSize;
                lL = config.AllowMediaExt;
                break;
            case 'flash':
                lH = config.AllowFlashSize;
                lL = config.AllowFlashExt;
                break;
            case 'file':
                lH = config.AllowFileSize;
                lL = config.AllowFileExt;
                break;
        }
        var V = '<table id="table_mfuarea" border=0 cellpadding=0 cellspacing=5 width="100%" height="100%" style="background-color:#d4d0c8;">' + '<tr>' + '<td id="td_mfuarea_msg" style="background-color:#808080;color:#ffffff;padding-left:5px;">' + lang['DlgComMFUMsgAllow'].replace('<ext>', lL).replace('<size>', wR(lH)) + '</td>' + '</tr>' + '<tr>' + '<td id="td_mfuarea_control" height="100%">' + '<object id="eWebEditorMFU" classid="CLSID:2D3B33A5-DF32-49B2-8ACB-9302FEAC292B" codebase="eWebEditor5.CAB#version=5,1,0,0" width="100%" height="100%"></object>' + '</td>' + '</tr>' + '</table>';
        this.nU.innerHTML = V;
        if (F.nb || F.BX) {
            var h = parseInt(this.nU.style.height) - $("td_mfuarea_msg").offsetHeight - 15;
            eWebEditorMFU.style.height = h + "px";
        }
        eWebEditorMFU.Lang = "zh-cn";
        eWebEditorMFU.Charset = config.Charset;
        eWebEditorMFU.SendUrl = EWEB.SendUrl;
        eWebEditorMFU.BlockSize = config.MFUBlockSize;
        eWebEditorMFU.FileType = this.yz;
        eWebEditorMFU.AllowSize = lH;
        eWebEditorMFU.AllowExt = lL;
        if (this.yQ == '0') {
            eWebEditorMFU.MultiFile = this.yQ;
        }
        this.AB = true;
    }
};
function wR(yf) {
    var n = parseFloat(yf);
    var s = "";
    if (n >= 1048576) {
        n = n / 1048576;
        s = Math.round(n * 100) / 100 + "GB";
    } else if (n >= 1024) {
        n = n / 1024;
        s = Math.round(n * 100) / 100 + "MB";
    } else {
        s = yf + "KB";
    }
    return s;
};
function DB(bv) {
    if (!bv) {
        return "";
    }
    if (bv.search(/[^0-9]+/) == -1) {
        return bv;
    } else {
        return bv + "px";
    }
}