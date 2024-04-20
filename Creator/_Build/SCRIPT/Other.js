const setFocus = () => {
    let tmp = document.querySelector("input.focus");

    if (tmp !== null) {
        tmp.focus();
    }
};

const copyToClipboard = (str) => {
    navigator.clipboard.writeText(str);
};

setFocus();


	//# sourceMappingUrl=Other.js.map
