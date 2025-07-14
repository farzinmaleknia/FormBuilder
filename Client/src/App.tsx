import { useAppDispatch, useAppSelector } from './hooks';
import { useEffect } from "react";
import { setResources } from "./store";
import { useResources } from "./hooks/useResources";
import { localResources } from "./data/Defaults.json";


function App() {
  const dispatch = useAppDispatch();
  const resources  = useAppSelector((state) => state.resources);
  
  useEffect(() => {
    const ResourcesAction = setResources(localResources);
    dispatch(ResourcesAction);
  }, []);
  console.log(resources);

  const isResourcesLoaded = useResources();

  return (
    <div className="">
      {isResourcesLoaded? <div className="text-3xl">FormBuilder</div> : null}
    </div>
  )
}

export default App
