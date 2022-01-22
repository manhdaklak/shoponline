/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';

  
config.syntaxhighlight_lang = 'csharp';
		config.syntaxhighlight_hideControls = true;
		config.languages = 'vi';
		config.filebrowserBrowseUrl = '/assest/Admin/ckfinder/ckfinder.html';
		config.filebrowserImageBrowseUrl = '/assest/Admin/ckfinder/ckfinder.html?Types=Images';
		config.filebrowserFlashBrowseUrl = '/assest/Admin/ckfinder/ckfinder.html?Types=Flash';
		config.filebrowserUploadUrl = '/assest/Admin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=File';
		config.filebrowserImageUploadUrl = '/Content/Images';
		config.filebrowserFlashUploadUrl = '/assest/Admin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

		CKFinder.setupCKEditor(null, '/assest/Admin/ckfinder/');
};
