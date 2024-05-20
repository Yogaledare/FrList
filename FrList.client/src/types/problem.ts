type Error = {
    Name?: string[];
    Age?: string[];
    Nick?: string[];
    Date?: string[];
};


type MemberValidationProblem = {
    type: string;
    title: string;
    status: number;
    errors: Error;
};

export default MemberValidationProblem;

