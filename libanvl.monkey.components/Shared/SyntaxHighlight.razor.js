import hljs from 'https://unpkg.com/@highlightjs/cdn-assets@11.3.1/es/highlight.min.js'

export function highlightAll() {
    hljs.highlightAll();
}

export function highlightContainer(rootElement) {
    rootElement.querySelectorAll('pre code').forEach((el) => hljs.highlightElement(el));
}

export async function registerLanguage(lang) {
    let langmod = await import('https://unpkg.com/@highlightjs/cdn-assets@11.3.1/es/languages/' + lang + '.min.js');
    hljs.registerLanguage(lang, langmod.default);
}