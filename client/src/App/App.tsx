import { FC } from "react";
import { Admin, Resource, ListGuesser, EditGuesser, ShowGuesser } from "react-admin";
import restProvider from "ra-data-simple-rest";
import polyglotI18nProvider from "ra-i18n-polyglot";
import PT_BR from "ra-language-pt-br";
import {
    EmployeeList,
    EmployeeIcon,
    EmployeeEdit,
    EmployeeCreate,
} from "../Components/Employees";
import { JobTitles } from "../Components/JobTitles";
// interface Props {
//     text?: string;
//     ok?: boolean;
//     number?: number;
//     fn?: (a: number, b: string) => string;
//     obj?: {
//         f1: string;
//     };
// }

const i18nProvider = polyglotI18nProvider(() => PT_BR, "br");

const App: FC = () => {
    return (
        <Admin
            dataProvider={restProvider("https://localhost:5001/api")}
            i18nProvider={i18nProvider}
        >
            <Resource
                name="funcionarios"
                create={EmployeeCreate}
                list={EmployeeList}
                edit={EmployeeEdit}
                // show={ShowGuesser}
                icon={EmployeeIcon}
            />
            {/* <Resource name="cargos" list={ListGuesser} edit={EditGuesser} show={ShowGuesser}></Resource> */}
        </Admin>
    );
};

export default App;
