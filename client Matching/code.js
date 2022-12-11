const baseUrl = "http://localhost:5162/api";
document.addEventListener("DOMContentLoaded", registerEvents);

function registerEvents() {
  document.getElementById("btnRais").addEventListener("click", GetRaisList);
  document
    .getElementById("btnDonation")
    .addEventListener("click", GetDonationList);
  א;
  var don = document
    .getElementById("newDonation")
    .addEventListener("submit", addNewDonation);
}

function GetRaisList() {
  fetch(`${baseUrl}/${"Rais"}`)
    .then((response) => response.json())
    .then((data) => {
      const d = document.getElementById("allRais");
      d.innerHTML = "";
      data.forEach((c) => {
        d.innerHTML += `<div class="one-rais">
                <img class="img-coin" src="Picture/coin without layer (1).png" alt="coin" />
                <h2 class="name-rais">${c.firstName} ${c.lastName}</h2>
                <br>
                <span class="price-rais">${c.donationsCollected}$</span>
                <span>From target of ${c.raisTarget}$</span>
              </div>`;
      });
    })
    .catch((error) => console.log(error));
}

function GetDonationList() {
  fetch(`${baseUrl}/${"Donation"}`)
    .then((response) => response.json())
    .then((data) => {
      const d = document.getElementById("allDonation");
      d.innerHTML = "";
      data.forEach((c) => {
        d.innerHTML += `<div class="one-donation">
                <div class="top-one-donation">
                  <p class="id-p">${c.id}</p>
                  <h1 class="price-h1">${c.amountOfDonation}$</h1>
                  <h3 class="name-h3">${c.donatesName}</h3>
                </div>
                <div class="bottom-one-donation">
                  <p>Donate by: ${c.fundRaiserName}</p>
                  <p>To the group ${c.nameGroup}</p>
                </div>
              </div>`;
      });
    })
    .catch((error) => console.log(error));
}

function addNewDonation(d) {
  document.getElementById("addD").style.display = "none";
  d.preventDefault();
  const donation = collectData();
  fetch(`${baseUrl}/${"Donation"}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(donation),
  })
    //.then((data) => data.json())
    .then((response) => response.json())
    .then(console.log(donation))
    .catch((error) => console.log(error));
  console.log("finish");
  const dataTarget = GetTarget();
  let t = {
    TargetSum: dataTarget.TargetSum,
    missingTrget: dataTarget.missingTrget - donation.amountOfDonation,
    collected: dataTarget.collected + donation.amountOfDonation,
    Deadline: dataTarget.Deadline,
  };

  updateTargets(t);
  GetDonationList();
}

function updateTargets(t) {
  console.log("updete target");
  const target = t;
  fetch(`${baseUrl}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(target),
  })
    .then((response) => response.json())
    .then(console.log(target))
    .catch((error) => console.log(error));
  console.log("finish");
  GetTarget();
}

function collectData() {
  let name = document.getElementById("name").value;
  let amount = document.getElementById("price").value;
  let rais = document.getElementById("rais").value;
  let fundraisingGroup = document.getElementById("fundraisingGroup").value;
  // document.getElementById("Name").value = "";
  // document.getElementById("amountOfDonation").value = 0;
  // document.getElementById("rais").value = "";
  // document.getElementById("fundraisingGroup").value = "";
  let newDonation = {
    donatesName: name,
    amountOfDonation: amount,
    FundRaiser: rais,
    FundraisingGroup: fundraisingGroup,
  };
  return newDonation;
}

function displayAdd() {
  document.getElementById("addD").style.display = "block";
}

function GetTarget() {
  fetch(`${baseUrl}/${"Targets/1"}`)
    .then((response) => response.json())
    .then((data) => {
      const t = document.getElementById("target-details");
      t.innerHTML = "";
      t.innerHTML += `<h2> Target ${data.targetSum}$</h2>
      <p>${data.collected}$ collected</p>
      <p>Missing another ${data.missingTrget}$ to reach the destination</p>`;
      var countDownDate = new Date(data.deadline).getTime();
      var x = setInterval(function () {
        var now = new Date().getTime();
        var distance = countDownDate - now;
        var days = Math.floor(distance / (1000 * 60 * 60 * 24));
        var hours = Math.floor(
          (distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)
        );
        var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((distance % (1000 * 60)) / 1000);
        document.getElementById(
          "timmer"
        ).innerHTML = `<div id="timmer-style">${days} d</div>
        <div id="timmer-style">${hours} h</div>
        <div id="timmer-style">${minutes} m</div>
        <div id="timmer-style">${seconds} s</div>`;
        if (distance < 0) {
          clearInterval(x);
          document.getElementById("timmer").innerHTML = "EXPIRED";
        }
      }, 1000);
    })
    .catch((error) => console.log(error));
  return data;
}
