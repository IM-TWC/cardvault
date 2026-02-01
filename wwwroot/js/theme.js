window.theme = {
  set: function (mode) {
    document.documentElement.classList.remove("light", "dark");
    document.documentElement.classList.add(mode);
    localStorage.setItem("theme", mode);
  },
  init: function () {
    const saved = localStorage.getItem("theme");
    if (saved) {
      document.documentElement.classList.add(saved);
    }
  }
};

window.theme.init();
