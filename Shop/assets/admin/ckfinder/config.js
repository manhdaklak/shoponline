/*
Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://cksource.com/ckfinder/license
*/

CKFinder.customConfig = function (config) {
	// Define changes to default configuration here.
	// For the list of available options, check:
	// http://docs.cksource.com/ckfinder_2.x_api/symbols/CKFinder.config.html

	// Sample configuration options:
	// config.uiColor = '#BDE31E';
	// config.language = 'fr';
	// config.removePlugins = 'basket';
	CKEDITOR.editorConfig = function (config) {
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
		config.filebrowserImageUploadUrl = '/Content/img/AoThun';
		config.filebrowserFlashUploadUrl = '/assest/Admin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

		CKFinder.setupCKEditor(null, '/assest/Admin/ckfinder/');
	};
}
