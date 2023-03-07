/**
         * overhang.min.js
         * Paul Krishnamurthy 2016
         *
         * https://paulkr.com
         * paul@paulkr.com
         */

$.fn.overhang = function (arguments) { var e = $(this), o = $("<div class='overhang'></div>"), a = $("<div class='overhang-overlay'></div>"); $(".overhang").remove(), $(".overhang-overlay").remove(); var n = { success: ["#2ECC71", "#27AE60"], error: ["#E74C3C", "#C0392B"], warn: ["#E67E22", "#D35400"], info: ["#3498DB", "#2980B9"], prompt: ["#9B59B6", "#8E44AD"], confirm: ["#1ABC9C", "#16A085"], default: ["#95A5A6", "#7F8C8D"] }, r = $.extend({ type: "success", custom: !1, message: "This is an overhang.js message!", textColor: "#FFFFFF", yesMessage: "Yes", noMessage: "No", yesColor: "#2ECC71", noColor: "#E74C3C", duration: 1.5, speed: 500, closeConfirm: !1, upper: !1, easing: "easeOutBounce", html: !1, overlay: !1, customClasses: "", callback: function () { } }, arguments); function s(n, s) { a.fadeOut(100), o.slideUp(r.speed, function () { n && r.callback(null !== s ? e.data(s) : "") }) } r.type = r.type.toLowerCase(); -1 === $.inArray(r.type, ["success", "error", "warn", "info", "prompt", "confirm"]) && (r.type = "default", console.log("You have entered invalid type name for an overhang message. Overhang resorted to the default theme.")), o.addClass(r.customClasses), r.custom ? (r.primary = arguments.primary || n.default[0], r.accent = arguments.accent || n.default[1]) : (r.primary = n[r.type][0] || n.default[0], r.accent = n[r.type][1] || n.default[1]), "prompt" !== r.type && "confirm" !== r.type || (r.primary = arguments.primary || n[r.type][0], r.accent = arguments.accent || n[r.type][1], r.closeConfirm = !0), o.css("background-color", r.primary), o.css("border-bottom", "6px solid " + r.accent); var t = $("<span class='overhang-message'></span>"); t.css("color", r.textColor), r.html ? t.html(r.message) : t.text(r.upper ? r.message.toUpperCase() : r.message), o.append(t); var c = $("<input class='overhang-prompt-field' />"), l = $("<button class='overhang-yes-option'>" + r.yesMessage + "</button>"), p = $("<button class='overhang-no-option'>" + r.noMessage + "</button>"); if (l.css("background-color", r.yesColor), p.css("background-color", r.noColor), r.closeConfirm) { var i = $("<span class='overhang-close'></span>"); i.css("color", r.accent), "confirm" !== r.type && o.append(i) } if ("prompt" === r.type ? (o.append(c), e.data("overhangPrompt", null), c.keydown(function (o) { 13 == o.keyCode && (e.data("overhangPrompt", c.val()), s(!0, "overhangPrompt")) })) : "confirm" === r.type && (o.append(l), o.append(p), o.append(i), e.data("overhangConfirm", null), l.click(function () { e.data("overhangConfirm", !0), s(!0, "overhangConfirm") }), p.click(function () { e.data("overhangConfirm", !1), s(!0, "overhangConfirm") })), e.append(o), o.slideDown(r.speed, r.easing), r.overlay && (r.overlayColor && a.css("background-color", r.overlayColor), e.append(a)), r.closeConfirm && !arguments.duration) i.click(function () { "prompt" !== r.type && "confirm" !== r.type ? s(!0, null) : s(!1, null) }); else if (r.closeConfirm && arguments.duration) { var u = setTimeout(function () { o.slideUp(r.speed, function () { s(!0, null) }) }, 1e3 * r.duration); i.click(function () { clearTimeout(u), "prompt" !== r.type && "confirm" !== r.type ? s(!0, null) : s(!1, null) }) } else o.delay(1e3 * r.duration).slideUp(r.speed, function () { s(!0, null) }) };
