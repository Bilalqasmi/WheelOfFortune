module.exports = {
    content: [
        './Pages/**/*.razor',
        './Shared/**/*.razor',
        "./wwwroot/index.html",
        "./node_modules/flowbite/**/*.js"
    ],
    darkMode: false, 
    theme: {
        extend: {},
    },
    variants: {
        extend: {},
    },
    plugins: [
        require('flowbite/plugin')
    ],
}
