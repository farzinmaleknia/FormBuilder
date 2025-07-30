import type {BaseQueryFn, FetchArgs, FetchBaseQueryError} from '@reduxjs/toolkit/query';
import type { ResultClass } from '../interfaces/ResultClass/ResultClass';
//import type { Resources } from '../interfaces/Resources/Resources';
import { createApi } from '@reduxjs/toolkit/query/react';
import { dynamicBaseQuery } from './dynamicBaseQuery';


const filesApi = createApi({
  reducerPath: 'files',
  baseQuery: dynamicBaseQuery as BaseQueryFn<string | FetchArgs, unknown, FetchBaseQueryError>,
  endpoints(builder){
    return {
      addFile: builder.mutation<ResultClass<Blob>, File>({
        query: (file) => {
          const formData = new FormData();
          formData.append("file", file);
          return {
            url: '/Files',
            method: 'Post',
            body: formData,
          }
        }
      })
    }
  }
});

export const { useAddFileMutation } = filesApi;
export { filesApi };