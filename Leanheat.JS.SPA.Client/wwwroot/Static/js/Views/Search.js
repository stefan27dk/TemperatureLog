// Imports
// Using the abstract class
import AbstractView from "./AbstractView.js";


// Class ###########################################################>
export default class extends AbstractView {

    // Constructor =================================================>
    constructor()
    {
        super(); // The abstract class Constructor "Base constructor"
        this.setTitle("Search");
    }



      // Get Html ====================================================>
      async getHtml()
      {
          return `
               <h1 class="subTitleView">Search by Date</h1>

               <form>
                <input id="datePicker" type="date"  name="date">
          </form>
          `;
      }


    // View Script ====================================================>
    async executeViewScript()
    {
        document.getElementById('viewTitle').innerText = 'Search'; // Change Tittle




        // Events ------------------------------------------------------->
        document.getElementById('datePicker').onchange = function () { alert(document.getElementById('datePicker').value);};
    }

}