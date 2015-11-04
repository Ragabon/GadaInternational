(function () {
    var config = {
        authority: "https://localhost:44309/identity",
        client_id: "implicitclient",
        redirect_uri: window.location.protocol + "//" + window.location.host + "/callback.html", //"/#/home",
        post_logout_redirect_uri: window.location.protocol + "//" + window.location.host + "/#/logout", ///index.html",

        // these two will be done dynamically from the buttons clicked
        response_type: "id_token token",
        scope: "openid profile", //roles

        // we're not using these in this sample
        silent_redirect_uri: window.location.protocol + "//" + window.location.host + "/silent_renew.html",
        //silent_renew: true,

        // this will allow all the OIDC protocol claims to vbe visible in the window. normally a client app
        // wouldn't care about them or want them taking up space
        filter_protocol_claims: false
    };

    var mgr = new OidcTokenManager(config);
    console.log(mgr._settings);
    console.log(mgr);
    window.mgr = mgr;

    mgr.addOnTokenObtained(function () {
        console.log("token obtained");
    });
    mgr.addOnTokenRemoved(function () {
        display("#response", { message: "Logged Out" });
        showTokens();
    });

    function display(selector, data) {
        if (data && typeof data === 'string') {
            data = JSON.parse(data);
        }
        if (data) {
            data = JSON.stringify(data, null, 2);
        }
        document.querySelector(selector).textContent = data;
    }

    function showTokens() {
        checkSessionState();
    }

    showTokens();

    function handleCallback() {
        mgr.processTokenCallbackAsync().then(function () {
            var hash = window.location.hash.substr(1);
            var result = hash.split('&').reduce(function (result, item) {
                var parts = item.split('=');
                result[parts[0]] = parts[1];
                return result;
            }, {});
            //display("#response", result);

            showTokens();
        }, function (error) {
            //display("#response", error.message && { error: error.message } || error);
            console.log(error);
        });
    }

    function authorize(scope, response_type) {
        config.scope = scope;
        config.response_type = response_type;
        mgr.redirectForToken();
    }

    function logout() {
        mgr.redirectForLogout();
    }

    if (window.location.hash) {
        handleCallback();
    }

    function checkSessionState() {
        mgr.oidcClient.loadMetadataAsync().then(function (meta) {
            console.log("loaded metadata: " + meta);
        });
    }

    window.onmessage = function (e) {
        if (e.origin === window.location.protocol + "//" + window.location.host && e.data === "changed") {
            mgr.removeToken();
        }
    }
})();