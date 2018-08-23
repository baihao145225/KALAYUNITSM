/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    //config.uiColor = '#39b2a9';
    config.width = 900;
    config.height = 300;
    config.resize_dir = 'both';
    resize_minWidth = 600;
    resize_minHeight = 300;
    resize_maxWidth = 1500;
    allowedContent = true;
    autoUpdateElement = true;
    removePlugins = 'elementspath,resize';
    extraPlugins = 'copyformatting,colorbutton';
    resize_enabled = false;
    config.toolbarGroups = [
            { "name": "basicstyles", "groups": ["basicstyles"] },
            { "name": "links", "groups": ["links"] },
            { "name": "paragraph", "groups": ["list", "blocks"] },
            { "name": "document", "groups": ["mode"] },
            { "name": "insert", "groups": ["insert"] },
            { "name": "styles", "groups": ["styles"] },
            { "name": "maximize", "groups": ["maximize"] }
    ];
};
