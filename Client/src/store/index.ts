import { configureStore } from "@reduxjs/toolkit";
import { setupListeners } from "@reduxjs/toolkit/query";
import resourcesReducer from "./slices/resources";
import { resourcesApi } from "./apis/resourcesApi";
import { filesApi } from "./apis/filesApi";

export const store = configureStore({
  reducer: {
    [resourcesApi.reducerPath]: resourcesApi.reducer,
    resources: resourcesReducer,
    [filesApi.reducerPath]: filesApi.reducer,
  },
  middleware: (getDefaultMitddleware) => {
    return getDefaultMitddleware()
      .concat(resourcesApi.middleware)
      .concat(filesApi.middleware)
  },
});

setupListeners(store.dispatch);

export { useFetchResourcesQuery } from "./apis/resourcesApi";
export { setResources } from "./slices/resources";

export { useAddFileMutation } from "./apis/filesApi"

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
