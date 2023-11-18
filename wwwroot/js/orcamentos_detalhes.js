const extractRentIdFromURL = () => {
  const urlPathName = window.location.pathname;
  const [rentId] = urlPathName.split("/").slice(-1);

  return rentId;
};

const createToolsLi = (rentTools) => {
  const toolsList = $("#tools-list");

  rentTools.forEach((toolDescription) => {
    const toolItem = $("<li></li>");

    toolItem.text(toolDescription);
    toolsList.append(toolItem);
  });
};

const searchToolsByRentId = async () => {
  const rentId = extractRentIdFromURL();

  const [response] = await $.get("/api/orcamentosapi/relatorios/" + rentId);
  const rentTools = response.processos_Many.map(
    ({ ferramenta_Orc }) => ferramenta_Orc.descricao
  );

  createToolsLi(rentTools);
};

$.ready.then(() => {
  searchToolsByRentId();
});
