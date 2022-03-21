import { MudEditor } from "./MudEditor"

class MudEditorBase {
    private editors = new Map<number, MudEditor>();

    create = (dotnetHelper, quillElement, placeholder):MudEditor => {
        var editor = new MudEditor(dotnetHelper, quillElement, placeholder);

        this.editors.set(dotnetHelper._id, editor);

        return editor.quill;
    };

    remove = (dotnetHelper) => {
        const id = dotnetHelper._id;
        if (this.editors.has(id)) {
            this.editors.get(id).stuff();
            this.editors.delete(id);
        }
    };
}

window["MudEditor"] = new MudEditorBase();