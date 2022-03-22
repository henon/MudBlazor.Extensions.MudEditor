import Quill from "quill/dist/quill.core.js";

export class MudEditor {
    public quill;

    constructor(private dotnetHelper, quillElement, placeholder) {
        const options = { placeholder: placeholder };

        this.quill = new Quill(quillElement, options);

        this.quill.on("editor-change", this.editorChange);
    }

    private editorChange = (eventName, ...args) => {
        if (eventName === "text-change") {
            // args[0] will be delta
        } else if (eventName === "selection-change") {
            // args[0] will be old range
        }

        console.log(this.dotnetHelper._id);
        console.log(args);

        this.dotnetHelper.invokeMethodAsync("QuillEvent", args);
    };

    stuff(): void {
        this.quill.off("editor-change", this.editorChange);
    }
}

export default Quill;