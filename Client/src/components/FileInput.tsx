import { Fragment } from "react/jsx-runtime";


interface InputProps {
  name: string;
  id: string;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  placeholder?: string;
  accept: string;
}

export const FileInput = ({
  name,
  id,
  onChange,
  placeholder,
  accept,
}: InputProps) => {
  return (
    <Fragment>
      <input
        name={name}
        id={id}
        type={'file'}
        accept={accept}
        className=" block border border-gray-300 rounded-md shadow-sm focus:border-blue-500 focus:outline-none m-2 px-4 py-2"
        onChange={(e) => onChange(e)}
        placeholder={placeholder}
      />
    </Fragment>
  );
};
