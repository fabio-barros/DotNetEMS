import { FC } from "react";
import { Admin, Resource, ListGuesser } from "react-admin";
import restProvider from "ra-data-simple-rest";
import polyglotI18nProvider from "ra-i18n-polyglot";
import PT_BR from "ra-language-pt-br";
import {
    EmployeeList,
    EmployeeIcon,
    EmployeeEdit,
    EmployeeCreate,
} from "../Components/Employees";
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
            dataProvider={restProvider("http://localhost:3000")}
            i18nProvider={i18nProvider}
        >
            <Resource
                name="funcionarios"
                list={EmployeeList}
                create={EmployeeCreate}
                edit={EmployeeEdit}
                icon={EmployeeIcon}
            />
        </Admin>
    );
};

export default App;
