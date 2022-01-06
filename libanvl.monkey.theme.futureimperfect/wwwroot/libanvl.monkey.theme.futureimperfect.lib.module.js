export async function afterStarted(blazor) {
    console.log("theme afterStarted");
    await import('https://kit.fontawesome.com/d9d1714b5b.js');

    /*
    Future Imperfect by HTML5 UP
    html5up.net | @ajlkn
    Free for personal and commercial use under the CCA 3.0 license (html5up.net/license)
*/

    window.setTimeout(() => {
        document.querySelector('body').classList.remove('is-preload');
    }, 2000);
}