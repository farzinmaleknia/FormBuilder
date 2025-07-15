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
      addFile: builder.mutation<ResultClass<boolean>, File>({
        query: (inputFile) => {
          return {
            url: '/Files',
            method: 'Post',
            body: {
              file: inputFile,
            },
          }
        }
      })
    }
  }
});

export const { useAddFileMutation } = filesApi;
export { filesApi };