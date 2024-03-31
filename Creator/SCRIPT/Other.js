const setFocus = () => {
    let tmp = document.querySelector("input.focus");

    if (tmp !== null) {
        tmp.focus();
    }
};

setFocus();
