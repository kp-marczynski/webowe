function cssVariable(variableName) {
    return getComputedStyle(document.body).getPropertyValue(variableName);
}

function createActionDialog({title, message, okMessage, cancelMessage, onOk, onCancel}) {

    const backgroundDom = document.createElement('div');
    const dialogSection = document.createElement('section');
    const titleDom = document.createElement("h6");
    const contentDom = document.createElement('span');
    const buttonsWrapper = document.createElement('div');
    const buttonOk = document.createElement('button');

    backgroundDom.style.height = '100vh';
    backgroundDom.style.width = '100%';
    backgroundDom.style.position = 'absolute';
    backgroundDom.style.top = '0';
    backgroundDom.style.left = '0';
    backgroundDom.style.background = 'rgba(0, 0, 0, .5)';

    dialogSection.style.position = 'absolute';
    dialogSection.style.top = '50%';
    dialogSection.style.left = '50%';
    dialogSection.style.transform = 'translate(-50%, -50%)';
    dialogSection.style.zIndex = '40';
    dialogSection.style.maxWidth = '600px';
    dialogSection.style.width = '90%';
    dialogSection.style.display = 'flex';
    dialogSection.style.flexDirection = 'column';
    dialogSection.style.background = cssVariable('--dialog-background');
    dialogSection.style.boxShadow = '0px 11px 15px -7px rgba(0,0,0,0.2), 0px 24px 38px 3px rgba(0,0,0,0.14), 0px 9px 46px 8px rgba(0,0,0,0.12)';


    titleDom.innerText = title;
    titleDom.style.fontSize = '1.25rem';
    titleDom.style.fontWeight = '500';
    titleDom.style.lineHeight = '1.6';
    titleDom.style.letterSpacing = '0.0075rem';
    titleDom.style.padding = '24px 24px 20px';
    titleDom.style.color = cssVariable("--dialog-title-color");

    contentDom.style.lineHeight = '1.5';
    contentDom.style.fontSize = '1rem';
    contentDom.style.fontWeight = '400';
    contentDom.style.letterSpacing = '0.00938rem';
    contentDom.style.color = cssVariable("--dialog-text-color");
    contentDom.style.padding = "0 24px 24px";

    buttonsWrapper.style.margin = '8px 4px';
    buttonsWrapper.style.display = 'flex';
    buttonsWrapper.style.alignItems = 'center';
    buttonsWrapper.style.justifyContent = 'flex-end';

    buttonOk.innerText = okMessage;
    buttonOk.style.margin = '0 4px';
    buttonOk.style.padding = '8px';
    buttonOk.style.fontSize = '0.875rem';
    buttonOk.style.minWidth = '64px';
    buttonOk.style.minHeight = '36px';
    buttonOk.style.transition = 'background-color 250ms cubic-bezier(0.4, 0, 0.2, 1) 0ms,box-shadow 250ms cubic-bezier(0.4, 0, 0.2, 1) 0ms,border 250ms cubic-bezier(0.4, 0, 0.2, 1) 0ms';
    buttonOk.style.fontWeight = '500';
    buttonOk.style.lineHeight = '1.5';
    buttonOk.style.borderRadius = '4px';
    buttonOk.style.letterSpacing = '0.02857em';
    buttonOk.style.textTransform = 'uppercase';
    buttonOk.style.cursor = 'pointer';
    buttonOk.style.outline = 'none';
    buttonOk.style.userSelect = 'none';
    buttonOk.style.backgroundColor = 'transparent';
    buttonOk.style.color = cssVariable('--primary-color');

    const buttonCancel = buttonOk.cloneNode(true);
    buttonCancel.innerText = cancelMessage;

    [buttonOk, buttonCancel].forEach(btn => {
        btn.addEventListener('mouseenter', () => {
            btn.style.backgroundColor = cssVariable('--dialog-button-hover-background');
        });

        btn.addEventListener('mouseleave', () => {
            btn.style.backgroundColor = 'transparent';
        });
    });

    backgroundDom.appendChild(dialogSection);
    contentDom.appendChild(document.createTextNode(message));

    buttonsWrapper.appendChild(buttonCancel);
    buttonsWrapper.appendChild(buttonOk);

    dialogSection.appendChild(titleDom);
    dialogSection.appendChild(contentDom);
    dialogSection.appendChild(buttonsWrapper);

    const closeAll = () => document.body.removeChild(backgroundDom);

    [titleDom, contentDom, buttonsWrapper].forEach(dom =>
        dom.onclick = (e) => e.stopPropagation());

    backgroundDom.onclick = () => {
        closeAll();
    };
    buttonOk.onclick = () => {
        closeAll();
        onOk && onOk();
    };
    buttonCancel.onclick = () => {
        closeAll();
        onCancel && onCancel();
    };

    return {
        open: () => {
            return document.body.appendChild(backgroundDom);
        },
        close: closeAll,
    }
}