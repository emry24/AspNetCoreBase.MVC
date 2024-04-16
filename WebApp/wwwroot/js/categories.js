document.addEventListener('DOMContentLoaded', function () {
    select()
    searchQuery()
})


function select() {

    try {
        let select = document.querySelector('.select')
        let selected = select.querySelector('.selected')
        let selectOptions = select.querySelector('.select-options')

        selected.addEventListener('click', function () {
            selectOptions.style.display = (selectOptions.style.display === 'block') ? 'none' : 'block'
        })

        let options = selectOptions.querySelectorAll('.option')
        options.forEach(function (option) {

            option.addEventListener('click', function () {
                selected.innerHTML = this.textContent
                selectOptions.style.display = 'none'
                let category = this.getAttribute('data-value')
                selected.setAttribute('data-value', category)
                updateCourseByFilter()

            })
        })
    }
    catch { }
}

function searchQuery() {

    try {
        document.querySelector('#searchQuery').addEventListener('keyup', function () {
            const value = this.value
            updateCourseByFilter()
        })
    }
    catch { }
}

function updateCourseByFilter() {

    const category = document.querySelector('.select .selected').getAttribute('data-value') || 'all'
    const searchQuery = document.querySelector('#searchQuery').value

    const url = `/courses/index?category=${encodeURIComponent(category)}&searchQuery=${encodeURIComponent(searchQuery)}`

    fetch(url)
        .then(res => res.text())
        .then(data => {
            const parser = new DOMParser()
            const dom = parser.parseFromString(data, 'text/html')
            const coursesGrid = document.querySelector('.courses-grid');
            document.querySelector('.courses-grid').innerHTML = dom.querySelector('.courses-grid').innerHTML

            const pagination = dom.querySelector('.pagination') ? dom.querySelector('.pagination').innerHTML : ''
            document.querySelector('.pagination').innerHTML = pagination

        })
}






