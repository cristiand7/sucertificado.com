var _token;
function Login(){
    //var username= document.getElementsByName("Username");
    //var Password= document.getElementsByName("Password");

    var req= new XMLHttpRequest();
    req.open("GET", "http://localhost:8080/api/values/Suma/3/4", false);
    req.send(null);
    console.log(req.responseText);




}

function Sum(fn){
	
	var req = new XMLHttpRequest();
	var query = "http://localhost:8080/api/values/suma/3/4";
	req.open("GET", encodeURI(query), true);
	// req.setRequestHeader("Authorization", "Bearer " + _token);  
	// req.setRequestHeader("Accept", "application/json");
	// req.setRequestHeader("Content-Type", "application/json;odata=verbose"); //charset=utf-8
	// req.setRequestHeader("OData-MaxVersion", "4.0");
	// req.setRequestHeader("OData-Version", "4.0");
	
	req.onreadystatechange = function () {
		if (this.readyState == 4) {
			req.onreadystatechange = null;
			
			switch(this.status){
				
				case 200:
                    var data = JSON.parse(this.response);           
                    fn(data);
					break;
				default:
					var error = JSON.parse(this.response).error;
					console.log("Error retrieving Record – " + error.message);
			}
		}
	};
	req.send();	
}

function Login(fn){
	
    var req = new XMLHttpRequest();
    var password= document.getElementById("Password").value;
    var username= document.getElementById("Username").value;

	var query = "http://localhost:8080/api/login/authenticate";
    req.open("POST", encodeURI(query), true);
	// req.setRequestHeader("Authorization", "Bearer " + _token);  
     req.setRequestHeader("Accept", "application/json");
	req.setRequestHeader("Content-Type", "application/json;odata=verbose"); //charset=utf-8
	 req.setRequestHeader("OData-MaxVersion", "4.0");
     req.setRequestHeader("OData-Version", "4.0");
    var obj = {};
	obj.username = username;
	obj.password = password;
	//obj.coem_startdate = survey.startDate;
	//obj.coem_enddate = survey.endDate;
	//obj["coem_mktList@odata.bind"] ="/lists("+ survey.mktList.id +")";
	//obj["coem_brand@odata.bind"] ="/coem_brands("+ survey.brand.id +")";
	var body = JSON.stringify(obj);
	
	
	req.onreadystatechange = function () {
		if (this.readyState == 4) {
			req.onreadystatechange = null;
			
			switch(this.status){
				
				case 200:
                    var data = JSON.parse(this.response);           
                    fn(data);
					break;
				default:
					var error = JSON.parse(this.response).error;
					console.log("Error retrieving Record – " + error.message);
			}
		}
	};
	req.send(body);	
}



function ShowData(data) {
console.log(data);
_token=data;

  }

  document.addEventListener("DOMContentLoaded", function(event) {
    var login = document.getElementById("Login");

    login.addEventListener("click", function (event){
        Login(ShowData);
    });
    
        
  });

