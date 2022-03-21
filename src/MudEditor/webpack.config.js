var path = require("path");

const RemoveEmptyScriptsPlugin = require("webpack-remove-empty-scripts");
const FileManagerPlugin = require("filemanager-webpack-plugin");

module.exports = {
    mode: "production",
    entry: {
        MudEditor: "./TScripts/MudEditorBase.ts",
        MudEditorStyles: "./Styles/MudEditor.scss"
    },
    devtool: "source-map",
    optimization: {
        runtimeChunk: false
    },
    resolve: {
        alias: {
            'quill-css': path.resolve(__dirname, "./node_modules/quill/dist/quill.core.css"),
/*            'parchment': path.resolve(__dirname, "./node_modules/parchment/src/parchment.ts"),*/
            'quill$': path.resolve(__dirname, "./node_modules/quill/quill.js")
        },
        extensions: [".ts", ".js", ".scss", ".css"]
    },
    output: {
        path: path.resolve(__dirname, "wwwroot"),
        filename: "[name].min.js",
        publicPath: "_content/MudEditor/" // << See note
    },
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: "ts-loader",
                exclude: /node_modules/
            },
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: []
            },
            {
                test: /\.scss$/,
                exclude: /node_modules/,
                type: "asset/resource",
                generator: {
                    filename: "[name].min.css"
                },
                use: ["sass-loader"]
            },
            {
                test: /\.css$/,
                exclude: /node_modules/,
                type: "asset/resource",
                generator: {
                    filename: "[name].min.css"
                },
                use: []
            }
        ]
    },
    plugins: [
        new RemoveEmptyScriptsPlugin(),
        new FileManagerPlugin({
            events: {
                onEnd: {
                    copy: [
                        { source: './wwwroot/MudEditor.min.css', destination: './Components/MudEditor.razor.css' }
                    ]
                }
            }
        })
    ]
};