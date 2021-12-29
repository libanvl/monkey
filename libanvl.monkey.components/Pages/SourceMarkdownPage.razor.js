import hljs from '/_content/libanvl.monkey.components/lib/highlight/core.js'

export async function highlightAll(lang) {
    let langmod = await import('/_content/libanvl.monkey.components/lib/highlight/languages/' + lang + '.min.js');
    hljs.registerLanguage(lang, langmod.default);

    hljs.highlightAll();

    document.querySelectorAll('pre code span').forEach((el) => {
        el.setAttribute('hljs-scope', '');
    });

    document.querySelectorAll('code.hljs').forEach((el) => {
        el.setAttribute('hljs-scope', '');
        el.parentElement.classList.add('hljs');
        el.parentElement.setAttribute('hljs-scope', '');
    });

    hljs.unregisterLanguage(lang);
}