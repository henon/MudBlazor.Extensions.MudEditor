export module Utils {
    function loadError(oError: any) {
        throw new URIError("The script " + oError.target.src + " didn't load correctly.");
    }

    export function prefixScript(url: string, onloadFunction: any) {
        const newScript: HTMLScriptElement = document.createElement("script");
        newScript.onerror = loadError;
        if (onloadFunction) { newScript.onload = onloadFunction; }
        document.currentScript.parentNode.insertBefore(newScript, document.currentScript);
        newScript.src = url;
    }
}

