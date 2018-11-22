getDocumentCookie = function () {
	return Promise.resolve(document.cookie);
};

navigatorLanguages = function () {
	return Promise.resolve(navigator.languages);
};
