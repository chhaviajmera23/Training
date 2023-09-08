
class Vehicle{

    constructor(vnumber,category,date,amount){

        this.vnumber = vnumber;

    

        this.category = category;

        this.date = date;

        this.amount = amount;

    }

}

class TollPlaza{

    Vehicles =[];

   

    getData(){

        if(localStorage.getItem("vehicles")!=undefined)

            this.Vehicles = JSON.parse(localStorage.getItem("vehicles"));

    }

 

    addNewEntry =(vh)=>{

        this.getData();

        this.Vehicles.push(vh);

        localStorage.setItem("vehicles",JSON.stringify(this.Vehicles));

    };

    findAmount(vh){

        if(vh=="Bike")

            return 10;

        else if(vh=="LMV")

            return 20;

        else if(vh=="HMV")

            return 30;

        else

            return 40;

    }

    getAllVehicles = () => {

        this.getData();

        return this.Vehicles;

    }

    getStringDate(dt){

        return `${dt.getDate()}/${dt.getMonth()+1}/${dt.getFullYear()}`;

    }

    findVehiclesById(id){

        this.getData();

        return this.Vehicles.filter((vh)=>vh.vnumber.toLowerCase()==id);

    }

    findVehiclesByDate(dt){

        this.getData();

        return this.Vehicles.filter((vh)=>this.getStringDate(dt)==this.getStringDate(new Date(vh.date)));

    }

    findVehiclesByCategory(cat){

        this.getData();

        return this.Vehicles.filter((vh)=>vh.category.toLowerCase()==cat);

    }

   

}