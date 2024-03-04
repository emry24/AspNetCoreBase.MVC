//const toggleMenu = () => {
//    document.getElementById('menu').classList.toggle('hide');
//    document.getElementById('account-buttons').classList.toggle('hide');
//}

const toggleMenu = () => {
    const menu = document.getElementById('menu');
    const accountButtons = document.getElementById('account-buttons');

    menu.classList.toggle('hide');
    accountButtons.classList.toggle('hide');

    menu.style.display = menu.classList.contains('hide') ? 'none' : 'block';
    accountButtons.style.display = accountButtons.classList.contains('hide') ? 'none' : 'flex';
}

const checkScreenSize = () => {
    if (window.innerWidth >= 1200) {
        document.getElementById('menu').classList.remove('hide');
        document.getElementById('account-buttons').classList.remove('hide');
    } else {
        if (!document.getElementById('menu').classList.contains('hide')) {
            document.getElementById('menu').classList.add('hide');
        }
        if (!document.getElementById('account-buttons').classList.contains('hide')) {
            document.getElementById('account-buttons').classList.add('hide');
        }
    }
};

//window.addEventListener('resize', checkScreenSize);
//checkScreenSize();

window.addEventListener('resize', function () {
    checkScreenSize();
});

checkScreenSize();
