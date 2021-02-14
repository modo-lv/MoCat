class NoticeBoard {

  constructor() {
    /**
     * How long to display notices with auto-hide enabled, in milliseconds.
     * @type {number}
     */
    this.autoHideAfterMillis = 3000;
  }

  /**
   * Initialize notice board handling.
   */
  init = async () => {
    // Auto-hide

  }

  /**
   * Enable
   * @param notice
   */
  autoHide = (notice) => {
    window.setTimeout(() => this.remove(notice), this.autoHideAfterMillis)
  }
}