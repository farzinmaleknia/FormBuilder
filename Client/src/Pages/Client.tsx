//import type { LoginForUpdateDTO } from "../store/interfaces/Update/LoginForUpdateDTO";
import { useEffect, useState } from "react";
import { useAppSelector } from "../hooks";
import { Button } from "../components/Button";
import { FileInput } from "../components/FileInput";
import { useAddFileMutation } from "../store";

const Client = () => {
  const [file, setFile] = useState<File | null>(null);
  const resources = useAppSelector((state) => state.resources);
  const [ addFile, results ] = useAddFileMutation();

  useEffect(() => {
    console.log(results)
  }, [results])

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    console.log(e.currentTarget.files);
    var files = e.currentTarget.files;
    if(files){
      setFile(files[0]);
    }
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    if(file != null)
      addFile(file);
  };

  return (
    <div>
      <form onSubmit={handleSubmit} className="w-120 flex flex-col">
        <div className="flex flex-col self-center">
          <label className="font-bold mx-2" htmlFor="username">
            {resources?.Titles.File} :
          </label>
          <FileInput
            name="Username"
            id="username"
            onChange={handleChange}
            accept=".pdf, application/pdf"
          ></FileInput>
        </div>
        <div className="flex justify-end">
          <Button type="submit">{resources?.Titles.Submit}</Button>
        </div>
      </form>
    </div>
  )
}

export default Client;